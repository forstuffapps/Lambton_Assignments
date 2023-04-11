from flask import Flask
from flask import render_template, redirect, request, session
from flask_session import Session
from cs50 import SQL

app = Flask(__name__)
SESSION_TYPE = 'filesystem'
app.config.from_object(__name__)
Session(app)

# def logedin():
#     if session.get('username') is not None:
#         return render_template('login.html')


db = SQL("sqlite:///db.db")

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/extention')
def extention():
    return render_template('extention.html')

@app.route('/about')
def about():
    return render_template('about.html')

@app.route('/login', methods=["GET", "POST"])
def login():
    # User reached route via POST (as by submitting a form via POST)

    session.clear()
    if request.method == "POST":
        row = db.execute("select * from users where username = :un", un = request.form.get('username'))
        if len(row) == 0:
            return render_template('login.html', msg = 'no match')
        if row[0]['password'] == request.form.get('password'):
            username = row[0]['username']
            session['username'] = row[0]['username']
            return render_template('tools.html', name = username)
        else:
            return render_template('login.html', msg = 'Wrong password')
    else:
        return render_template('login.html')


@app.route('/signup', methods=["GET", "POST"])
def signup():
     # User reached route via POST (as by submitting a form via POST)
      # User reached route via POST (as by submitting a form via POST)
    if request.method == "GET":
        return render_template("signup.html")
    else:
        if request.form.get('password') != request.form.get('cpassword'):
            return render_template('signup.html', msg = 'no match')

        else:
            row = db.execute("SELECT * FROM users WHERE username = :un ",
                              un = request.form.get('username'))
            if len(row) != 0:
                return render_template('signup.html', msg = "Username already exists")
            else:
                db.execute('INSERT INTO users (username, password) VALUES (:un, :pas)',
                            un = request.form.get('username'), pas = request.form.get('cpassword'))

    return redirect('/login')

@app.route("/tools")
def tools():
    # logedin()
    return render_template('tools.html')

@app.route("/logout")
def logout():
    return redirect('/bye')

@app.route("/bye")
def bye():
    un = session['username']
    session.clear()
    return render_template('bye.html', name = un)

@app.route("/bmi", methods=["GET", "POST"])
def bmi():
    if request.method == "GET":
        rows = db.execute('Select * from bmi where username = :username  ORDER by datetime desc limit 15',
                            username = session['username'])
        bmi = '--:--'
        heightl = ['Height']
        weightl = ['Weight']
        bmil = ['BMI']
        datel = ['Date']
        ln = 1
        result = ['Category']
        for i in range(len(rows)):
            if rows[i - 1]['bmi'] != rows[i]['bmi']:
                heightl.append(rows[i]['height'])
                weightl.append(rows[i]['weight'])
                bmil.append(rows[i]['bmi'])
                datel.append(rows[i]['date'])
                if rows[i]['bmi'] >= 18.5 and rows[i]['bmi'] < 25:
                    result.append('Normal')
                if rows[i]['bmi'] > 25 and rows[i]['bmi'] < 30:
                    result.append('Overweight')
                if rows[i]['bmi'] > 30:
                    result.append('Obese')
                if rows[i]['bmi'] < 18.5:
                    result.append('Underweight')
                ln += 1

        return render_template('bmi.html',name = session['username'],bmi = bmi, weight = weightl, height = heightl, bmil = bmil, date = datel, ln =ln, result = result)
    else:
        height = int(request.form.get('height'))
        height = height/100
        weight = int(request.form.get('weight'))
        bmi = '%.2f' % (weight / (height * height))

        db.execute('INSERT INTO bmi (username, height, weight, bmi) VALUES (:username, :height, :weight, :bmi)',
                                    username = session['username'], height = height, weight = weight, bmi = bmi)
        rows = db.execute('Select * from bmi where username = :username  ORDER by datetime desc limit 15',
                            username = session['username'])
        heightl = ['Height']
        weightl = ['Weight']
        bmil = ['BMI']
        datel = ['Date']
        ln = 1
        result = ['Category']
        for i in range(len(rows)):
            if rows[i - 1]['bmi'] != rows[i]['bmi']:
                heightl.append(rows[i]['height'])
                weightl.append(rows[i]['weight'])
                bmil.append(rows[i]['bmi'])
                datel.append(rows[i]['date'])
                if rows[i]['bmi'] >= 18.5 and rows[i]['bmi'] < 25:
                    result.append('Normal')
                if rows[i]['bmi'] > 25 and rows[i]['bmi'] < 30:
                    result.append('Overweight')
                if rows[i]['bmi'] > 30:
                    result.append('Obese')
                if rows[i]['bmi'] < 18.5:
                    result.append('Underweight')
                ln += 1

        return render_template('bmi.html',name = session['username'],bmi = bmi, weight = weightl, height = heightl, bmil = bmil, date = datel, ln =ln, result = result)

