import requests
import json
import time
import sys

sys.setrecursionlimit(15000)


# import required modules
from configparser import ConfigParser
import requests
from tkinter import *
from tkinter import messagebox

# extract key from the
# configuration file
config_file = "config.ini"
config = ConfigParser()
config.read(config_file)
#api_key = config['gfg']['api']
api_key = '6f1b6f13e6b4aa1ac4740f3488928fe3'
url = 'http://api.openweathermap.org/data/2.5/weather?q={}&appid={}'


# explicit function to get
# weather details
def getweather(city):
	result = requests.get(url.format(city, api_key))
	
	if result:
		json = result.json()
		city = json['name']
		country = json['sys']
		temp_kelvin = json['main']['temp']
		temp_celsius = temp_kelvin-273.15
		weather1 = json['weather'][0]['main']
		final = [city, country, temp_kelvin,
				temp_celsius, weather1]
		return final
	else:
		print("NO Content Found")


    



# explicit function to
# search city
def search():
	city = city_text.get()
	weather = getweather(city)
	if weather:
		location_lbl['text'] = '{}'.format(weather[0],)
		temperature_label['text'] = str(weather[3])+" Degree Celsius"
		weather_l['text'] = weather[4]
	else:
		messagebox.showerror('Error', "Cannot find {}".format(city))


# Driver Code
# create object
app = Tk()
# add title
app.title("Weather App")
# adjust window size
app.geometry("300x300")

# add labels, buttons and text
city_text = StringVar()
city_entry = Entry(app, textvariable=city_text)
city_entry.pack()
Search_btn = Button(app, text="Search Weather",
					width=12, command=search)
Search_btn.pack()
location_lbl = Label(app, text="Location", font={'bold', 20})
location_lbl.pack()
temperature_label = Label(app, text="")
temperature_label.pack()
weather_l = Label(app, text="")
weather_l.pack()


temp = Label(app, text=city_text.get())

temp.pack()

def countdown(count):
    if count==0 and city_entry==True:
        search()
        app.after(1000, countdown(3))
    else:
        timer["text"]=count
        app.after(1000,countdown(count-1))
        
timer = Label(app,text="")
timer.pack()
timer.place(x=125, y=125)



def update_weather():
    search()
    app.after(5000, update_weather)


#update_weather()


app.mainloop()
    




'''
for i in range(5):
    for i in range(5):
        timer = Label(app)
        #timer["text"] = i+1
        timer.place(x=35, y=15)
        app,after()
        time.sleep(1)
'''

    





'''
response = requests.get("http://api.openweathermap.org/data/2.5/weather?q=Sarnia,ON,CA&appid=6f1b6f13e6b4aa1ac4740f3488928fe3")
print(response.json()['weather']['main'])


with open('person.txt', 'w') as json_file:
  json.dump(response.json(), json_file)
  '''