import json
import tkinter as tk
import datetime
from tkinter import INSERT

import yaml
import requests

root = tk.Tk()  # create a root widget
root.title("Tk Example")
# root.configure(background="yellow")
root.minsize(400, 200)  # width, height
root.maxsize(500, 500)
# set window size
root.geometry("400x300")

# set background color to white
# root.configure(bg="white")
# root.geometry("300x300+50+50")  # width x height + x + y

# Create a label for the search bar
label = tk.Label(root, text="Search:")
label.pack(side="left")

# Create an entry widget for the search bar
entry = tk.Entry(root, width=30)
entry.pack(side="left")

def time_format_for_location(utc_with_tz):
    local_time = datetime.datetime.utcfromtimestamp(utc_with_tz)
    return local_time.time()

def get_input(event=None):
    kelvin = 273.15
    city = entry.get()
    API_KEY = "d9bf722777bb1e016002fb8a08a080e1"
    BASE_URL = "https://api.openweathermap.org/data/2.5/weather?"
    URL = BASE_URL + "q=" + city + "&appid=" + API_KEY
    print(city)
    response = json.loads(requests.get(URL).text)
    curr_temparature = response['main']['temp'] - kelvin
    feels_like = response['main']['feels_like'] - kelvin
    temp_min = response['main']['temp_min'] - kelvin
    temp_max = response['main']['temp_max'] - kelvin
    humidity = response['main']['humidity'] - kelvin
    wind_speed = response['wind']['speed'] * 3600 / 1000
    pressure = response['main']['pressure']
    timezone = response['timezone']
    sunrise = response['sys']['sunrise']
    sunset = response['sys']['sunset']
    cloudy = response['clouds']['all']
    description = response['weather'][0]['description']

    sunrise_time = time_format_for_location(sunrise + timezone)
    sunset_time = time_format_for_location(sunset + timezone)

    weather = f"\nWeather of: {city}\n" \
              f"Temperature : {curr_temparature}°C\n" \
              f"Feels like in : {feels_like}°C\n" \
              f"Pressure: {pressure} hPa\n" \
              f"Humidity: {humidity}%\n" \
              f"Sunrise at {sunrise_time} and Sunset at {sunset_time}\n" \
              f"Cloud: {cloudy}%\n" \
              f"Info: {description}" \
              f"temp_min: {temp_min}" \
              f"temp_max: {temp_max}" \
              f"wind_speed: {wind_speed}"
    tfield.insert(INSERT, weather)

tfield = tk.Text(root)
tfield.pack()

# on clock enter take input
entry.bind("<Return>", get_input)

# Create a button for submitting the search
button = tk.Button(root, text="Search", command=get_input)
button.pack(side="left")



clock = tk.Label(root, font=('Helvetica', 30), bg='white', fg='black')
clock.pack(pady=30)

def load_yaml():
    with open("next_interval_time.yaml", 'r') as fstrm:
        strm_data = yaml.safe_load(fstrm)
        ti = strm_data["time_interval"][0]
        # time interval in seconds
        return ti

def convert_sec_to_ms(seconds: int):
    return seconds*1000

def update_time():
    seconds = load_yaml()
    curr_time = datetime.datetime.now()
    curr_time += datetime.timedelta(seconds=seconds)
    curr_time = curr_time.strftime('%Y-%m-%d \n %H:%M:%S')
    text = f"Weather will update at this time \n {curr_time}"
    clock.config(text=text)
    t = convert_sec_to_ms(seconds)
    clock.after(t, update_time)

update_time()



# load_yaml()
root.mainloop()