import greet
greet.hello()
greet.bye()

from greet import hello,bye#same
hello()
bye()

#random
from random import randint
result = randint(1,6)
print(result)

#datetime
from datetime import date,datetime
today_date = date.today()
current_time = datetime.now()
print(today_date)
print(current_time)
