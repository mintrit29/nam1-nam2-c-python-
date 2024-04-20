result=(lambda x,y: x+y)(2,3)
print(result)

#map
numbers = [1,2,3,4,5]
def square(x):
    return x*x
new_list = list(map(square, numbers))
print(new_list)

#using map in different way
numbers = ['1', '2', '3', '4', '5']
result = list(map(int, numbers))
print(result)

prices = [100,200,300,400,500]
new_list = list(map(lambda x: x - x*5/100, prices))
print(new_list)

names = ['triet','minh','tung','tuan','anh']
new_list=list(map(str.capitalize, names))
print(new_list)

#filter in python
numbers=[1,2,3,4,5,6,7,8,9,10]
'''def odd(x):
    if x%2!=0:
        return x
#new_list = list(filter(odd, numbers))'''
new_list = list(filter(lambda x: x%2!=0, numbers))
print(new_list)

#generator function
def even_generator(x):
    for i in range(x):
        if i%2==0:
            yield i
print(list(even_generator(11)))

#C to F using map
celsius_temperature = [25,30,15,10,35]
result = list(map(lambda c: (c*9/5)+32,celsius_temperature))
print(result)

#extract initial from name
names = ['John Doe','Alice Smith','Bob Ford']
#for name in names:
    #print(name.split()[1][0])#first character of the last name
    #print(name.split()[0][0]+name.split()[1][0])#we also can plus
#result = list(map(lambda name: [n[0]for n in name.split()],names))#[['J', 'D'], ['A', 'S'], ['B', 'F']]
result = list(map(lambda name: "".join([n[0]for n in name.split()]),names))
print(result)

#reverse list using map
words = ['Python','Java','C++','Javascript']
reversed = list(map(lambda word:word[::-1],words))
print(reversed)
