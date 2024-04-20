def add(a,b):
    print(a+b)
add(10,20)
add(19,23)

def speed(distance,time):
    print(distance/time)
speed(time=2,distance=100)
speed(100,2)

def area(radius,pi=3.14):
    print(pi*radius*radius)
area(10)
area(10,3.15)#can change default value

def area(radius,pi=3.14):
    result = (pi*radius*radius)
    return result
def cost(circle_area,cost_per_sqm):
    total_cost = (circle_area*cost_per_sqm)
    return total_cost
caculated_area = area(10,3.15)
tc = cost(caculated_area,2)
print(tc)
tc = cost(area(10,3.15),2)#same
print(tc)
print(cost(area(10,3.15),2))#same

#Return multiple value
def circle(r):
    area = 3.14 * r * r
    circuference = 2 * 3.14 * r
    return area,circuference
a,c = circle(10)
print(f'Area of the circle is {a}, circuference of the circle is {c}')

#Passing a list to a function
def add(numbers):
    total = 0
    for number in numbers:
        total = total + number
    return total
scores=[1,2,3,4,5]
print(add(scores))

#function return a list 
def remove_duplicates(numbers):
    '''new_list=[]
    for number in numbers:
        if number not in new_list:
            new_list.append(number)
    return new_list'''
    return list(set(numbers))
ids = [1,2,2,3,4,4,6,6,5,7,10]
print(remove_duplicates(ids))

#accessing global variables inside a funtion
count = 10 
def increment():
    global count
    count = count + 1
    print(count)
increment()

#check if a string is palindrome
def check_palindrome(word):
    l = len(word)
    for i in range(l):
        if word[i] != word[l-i-1]:
            return False
    return True

word = input('Enter the word you want to check: ')
if (check_palindrome(word)) == True:
    print(f'{word} is a palindrome')
else:
    print(f'{word} is not a palindrome')