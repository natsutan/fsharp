# chap1 Accessing Data with Type Providers
-----
# Data Science Workflow

# Why Choose F# for Data Science?

# Calling the Open Weather Map REST API
用意されていないデータに対してはREST APIを呼ばないといけない。  

http://api.openweathermap.org/data/2.5/forecast/daily?q=Cambridge,  

type Weather = JsonProvider<"http://api.openweathermap.org/data/2.5/forecast/daily?units=metric&q=Prague">
