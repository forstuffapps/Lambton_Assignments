import sys
import requests
from configparser import ConfigParser
from tkinter import *
from tkinter import messagebox

sys.setrecursionlimit(15000)

# Load API key from configuration file
config_file = "config.ini"
config = ConfigParser()
config.read(config_file)
api_key = '6f1b6f13e6b4aa1ac4740f3488928fe3'

# OpenWeatherMap API URL
api_url = 'http://api.openweathermap.org/data/2.5/weather?q={}&appid={}'

# Fetch weather data for a given city
def fetch_weather(city_name):
    response = requests.get(api_url.format(city_name, api_key))
    
    if response:
        data = response.json()
        city = data['name']
        sys_data = data['sys']
        temperature_k = data['main']['temp']
        temperature_c = temperature_k - 273.15
        weather_condition = data['weather'][0]['main']
        return [city, sys_data, temperature_k, temperature_c, weather_condition]
    else:
        print("No content found")

search_started = False

# Search and display weather data for the entered city
def perform_search():
    global search_started
    search_started = True
    city = city_var.get()
    weather_data = fetch_weather(city)
    if weather_data:
        location_label['text'] = weather_data[0]
        temp_label['text'] = f"{weather_data[3]} Degree Celsius"
        weather_label['text'] = weather_data[4]
    else:
        messagebox.showerror('Error', f"Cannot find {city}")

# Create Tkinter app
app = Tk()
app.title("Weather Application")
app.geometry("300x300")

# Add UI elements
city_var = StringVar()
city_input = Entry(app, textvariable=city_var)
city_input.pack()

search_button = Button(app, text="Search Weather", width=12, command=perform_search)
search_button.pack()

location_label = Label(app, text="Location", font={'bold', 20})
location_label.pack()

temp_label = Label(app, text="")
temp_label.pack()

weather_label = Label(app, text="")
weather_label.pack()

# Timer function
def update_timer(time_remaining):
    if time_remaining > 0:
        timer_label["text"] = time_remaining
        app.after(1000, update_timer, time_remaining - 1)

# Automatically update weather data
def auto_update_weather():
    global search_started
    if search_started:
        perform_search()
        update_timer(5)
    app.after(5000, auto_update_weather)

# Initialize auto-update
auto_update_weather()

timer_label = Label(app, text="")
timer_label.pack()
timer_label.place(x=125, y=125)

app.mainloop()
