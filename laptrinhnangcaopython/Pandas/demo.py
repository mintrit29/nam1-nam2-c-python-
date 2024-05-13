#VD01 - Pandas
import pandas as pd

#DataFrames like table
#Series like column
a=[1,7,2]
myvar = pd.Series(a, index = ["x","y","z"])

print(myvar)
print(myvar["y"])

calories = {"day1":420, "day2":380, "day3":390}
var = pd.Series(calories)
print(var)

myvar = pd.Series(calories, index = ["day1","day2"])
print(myvar)