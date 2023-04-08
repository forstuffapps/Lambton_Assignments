import io
import requests
import configparser
import datetime

from PIL import Image, ImageTk
from tkinter import Tk, Label
from datetime import datetime
import os

class WeatherApp:

    def set_configurations(self):
        self.configurations = configparser.ConfigParser()
        loc = os.path.dirname(os.path.abspath(__file__))
        self.configurations.read(loc+'\config.ini')
        self.city = self.configurations["configs"]["city"]
        self.interval = int(self.configurations["configs"]["interval"])
        self.api_key = self.configurations["configs"]["api_key"]

    def get_weather_url(self):
        return f'http://api.openweathermap.org/data/2.5/weather?q={self.city}&appid={self.api_key}&units=metric'

    def get_icon_url(self, icon_code):
        return f'http://openweathermap.org/img/w/{icon_code}.png'

    def setup_location_label(self):
        self.location_label = Label(self.initiator, text=self.city.title(), font=("Helvetica", 20))
        self.location_label.pack()

    def setup_icon_label(self):
        self.icon_label = Label(self.initiator)
        self.icon_label.pack()

    def setup_icon_config(self):
        icon_value = self.weather_details['weather'][0]['icon']
        icon = ImageTk.PhotoImage(Image.open(io.BytesIO(requests.get(self.get_icon_url(icon_value)).content)))
        self.icon_label.config(image=icon)
        self.icon_label.image = icon

    def convert_farenheit(self, celsius_value):
        return round(celsius_value * 1.8 + 32, 1)

    def setup_climate_label(self):
        self.climate_label = Label(self.initiator, font=("Helvetica", 40))
        self.climate_label.pack()

    def setup_climate_config(self):
        celsius_value = self.weather_details['main']['temp']
        self.climate_label.config(text=f'{round(celsius_value, 1)} °C\n{self.convert_farenheit(celsius_value)} °F')

    def setup_description_label(self):
        self.description_label = Label(self.initiator, font=("Helvetica", 15))
        self.description_label.pack()

    def setup_description_config(self):
        self.description_label.config(text=self.weather_details['weather'][0]['description'].title())
    
    def setup_time_label(self):
        now = datetime.now()
        time_string = now.strftime("%H:%M:%S")
        print(now)
        self.time_label = Label(self.initiator, font=("Helvetica", 20))
        self.time_label.pack()  

    def setup_time_config(self):
        self.time_label.config(text=datetime.utcnow().strftime("%a, %d %b %Y\n%H:%M:%S %Z"))
        self.time_label.after(1000, self.setup_time_config)

    def setup_labels(self):
        self.setup_location_label()
        self.setup_climate_label()
        self.setup_icon_label()
        self.setup_description_label()
        self.setup_time_label()

    def setup_config_labels(self):
        self.setup_icon_config()
        self.setup_climate_config()
        self.setup_description_config()

    def setup_tkinter(self):
        self.initiator = Tk()
        self.initiator.title("Weather App")
        self.setup_labels()

    def fetch_weather(self):
        self.weather_details = requests.get(self.get_weather_url()).json()
        self.setup_config_labels()

    def setup_timer(self):
        self.fetch_weather()
        self.initiator.after(self.interval * 60 * 1000, self.setup_timer)

    def end_tkinter(self):
        self.initiator.mainloop()

    def __init__(self):
        self.set_configurations()
        self.setup_tkinter()
        self.fetch_weather()
        self.setup_time_config()
        self.setup_timer()
        self.end_tkinter()


if __name__ == "__main__":
    WeatherApp()