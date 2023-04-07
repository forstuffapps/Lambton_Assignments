import requests
from datetime import *
from PIL import ImageTk, Image
from urllib.request import urlopen
import requests
from tkinter import *
import os

q = os.path.dirname(os.path.abspath(__file__))
with open (q+'/config.txt', 'r') as myfile: 
	w=[]
	for i in myfile:
		w.append(i.split('\n')[0])
	city = w[0]
	api_key = w[1]
	n = int(w[2])


url = 'http://api.openweathermap.org/data/2.5/weather?q={}&appid={}'


def search(city,api_key):
	result = requests.get(url.format(city, api_key))

	json = result.json()
	city = json['name']
	country = json['sys']
	temp_kelvin = json['main']['temp']
	temp_celsius = temp_kelvin-273.15
	temp_fah = ((9*temp_celsius)/5)+32
	weather1 = json['weather'][0]['main']
	img_id = json['weather'][0]['icon']
	final = [city, country, temp_kelvin, temp_celsius,temp_fah,  weather1,img_id]
	return final

final = search(city,api_key)

app = Tk()
# add title
app.title("Weather App")
# adjust window size
app.geometry("300x300")

# add labels, buttons and text

location_lbl = Label(app, text="Location", font={'bold', 20})
location_lbl.pack()
temperature_label = Label(app, text="")
temperature_label.pack()
weather_l = Label(app, text="")
weather_l.pack()




location_lbl['text'] = '{}'.format(final[0],)
temperature_label['text'] = str(final[3])+" Degree Celsius,   \n" + str(final[4])+" Degree Farenheit" 
weather_l['text'] = final[5]



img_url = "https://openweathermap.org/img/wn/{}@2x.png".format(final[6])
u = urlopen(img_url)
raw_data = u.read()
u.close()

img = ImageTk.PhotoImage(data=raw_data)
panel = Label(app, image=img)
panel.image = img
panel.pack()



q=str(datetime.now()).split()
date_time = Label(app, text=q[0]+'\n'+datetime.now().strftime("%H:%M:%S"))
date_time.pack()
def date_n_time():
	date_time['text']=q[0]+'\n'+datetime.now().strftime("%H:%M:%S")
	app.after(1000,date_n_time)

app.after(1000,date_n_time)


timer = Label(app,text="")
timer.pack()
#timer.place(x=125, y=125)	

def ti(t):
	#q=str(datetime.now()).split()
	#date_time['text']=q[0]+'\n'+q[1]
	if t>0:
		timer["text"]=t
		app.after(1000, ti, t-1)
	else:
		search(city,api_key)
		app.after(1000, ti, 5)







ti(n)

app.mainloop()


