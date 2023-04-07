import requests
import json
import time
import sys
from datetime import *
import time
from PIL import ImageTk, Image
import os
from io import BytesIO
from urllib.request import urlopen


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
		temp_fah = ((9*temp_celsius)/5)+32
		weather1 = json['weather'][0]['main']
		img_id = json['weather'][0]['icon']
		final = [city, country, temp_kelvin,
				temp_celsius,temp_fah,  weather1,img_id]
		return final
	else:
		print("NO Content Found")


	

flag = False

# explicit function to
# search city
def search():
	global flag
	flag = True
	city = city_text.get()
	weather = getweather(city)
	if weather:
		location_lbl['text'] = '{}'.format(weather[0],)
		temperature_label['text'] = str(weather[3])+" Degree Celsius,   \n" + str(weather[4])+" Degree Farenheit" 
		weather_l['text'] = weather[5]
		
		img_loc = str(weather[6])+'.png'
		print(img_loc)
		#display_img(img_loc)
		#print('qwe' + img_loc)
		
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


'''
frame = Frame(app, width=6, height=4)
frame.pack()
frame.place(anchor='center', relx=0.5, rely=0.5)
img = ImageTk.PhotoImage(Image.open("images/10d.png"))
img_label = Label(frame, image = img)
img_label.pack()
'''

def display_img(img_loc):
	qq = os.path.abspath(__file__)
	qq=qq.split("\\")[0:-1]
	qq='/'.join(qq) + '/images/'
	print(qq+img_loc)
	photo = PhotoImage(file=qq+img_loc)
	varun_label['image']=photo


img_url = "https://openweathermap.org/img/wn/01d@2x.png"
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

temp = Label(app, text=city_text.get())

temp.pack()
		
timer = Label(app,text="")
timer.pack()
#timer.place(x=125, y=125)

def ti(t):
	#q=str(datetime.now()).split()
	#date_time['text']=q[0]+'\n'+q[1]
	if t>0:
		timer["text"]=t
		app.after(1000, ti, t-1)



def update_weather():
	global flag
	if flag:
		search()
		ti(5)
	app.after(5000, update_weather)




update_weather()

app.mainloop()
	
