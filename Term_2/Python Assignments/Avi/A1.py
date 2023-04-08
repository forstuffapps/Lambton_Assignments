#Avinash Baddam
#c0877290
import requests
from datetime import datetime
from PIL import ImageTk, Image
from urllib.request import urlopen
import os
from tkinter import *

# Constants
CONFIG_FILENAME = 'config.txt'
#URL directs us to fetch the weather of the given cities
WEATHER_URL = 'http://api.openweathermap.org/data/2.5/weather?q={}&appid={}'

# Functions which read the data in the configuration files
def read_config_file(filename):
    with open(filename, 'r') as f:
        lines = f.readlines()
    city = lines[0].strip()
    api_key = lines[1].strip()
    n = int(lines[2])
    return city, api_key, n
#Function which convert the temperature from default kelvins to  celicius and fahrenheit
def get_weather_info(city, api_key):
    result = requests.get(WEATHER_URL.format(city, api_key))
    my_json_data = result.json()
    my_city_name = my_json_data['name']
    my_country = my_json_data['sys']
    my_temp_kelvin = my_json_data['main']['temp']
#formula to convert the kelvins to celcius
    my_temp_celsius = my_temp_kelvin - 273.15
#formula to convert the celcius to fahrenheit
    my_temp_fah = ((9 * my_temp_celsius) / 5) + 32
    my_weather_description = my_json_data['weather'][0]['main']
    my_icon_id = my_json_data['weather'][0]['icon']
    my_wind_speed = my_json_data['wind']['speed']
#final weather information
    my_weather_info = [my_city_name, my_country, my_temp_kelvin, 
    my_temp_celsius, my_temp_fah, my_weather_description, my_icon_id, my_wind_speed]
    return my_weather_info
#function to update the time
def update_time():
    now = datetime.now()
    current_time_lbl['text'] = now.strftime("%Y-%m-%d \n\n %H:%M:%S")
    app.after(1000, update_time)

# Main program
if __name__ == '__main__':
# Read configuration file
    config_filename = os.path.join(os.path.dirname(os.path.abspath(__file__)), CONFIG_FILENAME)
    city, api_key, n = read_config_file(config_filename)

# Fetch present weather information
    current_weather = get_weather_info(city, api_key)

# Creating GUI with Tkinter
    app = Tk()
    app.title("Weather App")
    app.geometry("500x700")
    app.configure(bg='#192A51')
# Add widgets
    b = "#192A51"
    i = '#ffffff'
    location_lbl = Label(app, text="Location", font=('bold', 40), background=b, fg=i)
    location_lbl.pack()

    temperature_lbl = Label(app, text="", font=('bold', 60), background=b, fg=i)
    temperature_lbl.pack()

    weather_lbl = Label(app, text="", font=('bold', 40), background=b, fg=i)
    weather_lbl.pack()

    icon_panel = Label(app, image=None, font=('bold', 40), background=b, fg=i)
    icon_panel.pack()

    current_time_lbl = Label(app, text="", font=('bold', 40), background=b, fg=i)
    current_time_lbl.pack()

    Wind_speed_lbl = Label(app, text="", font=('bold', 40), background=b, fg=i)
    Wind_speed_lbl.pack()

    # Update widgets with initial data
    location_lbl['text'] = current_weather[0]
    temperature_lbl['text'] = f"{current_weather[3]:.2f} \u00b0C \n {current_weather[4]:.2f} \u00b0F"
    weather_lbl['text'] = current_weather[5]
    Wind_speed_lbl['text'] = 'Wind Speed : ' + str(current_weather[7])

    icon_url = f"https://openweathermap.org/img/wn/{current_weather[6]}@2x.png"
    with urlopen(icon_url) as u:
        raw_data = u.read()
    icon_img = ImageTk.PhotoImage(data=raw_data)
    icon_panel.configure(image=icon_img)
    icon_panel.image = icon_img

    update_time()

    # Start GUI event loop
    app.mainloop()