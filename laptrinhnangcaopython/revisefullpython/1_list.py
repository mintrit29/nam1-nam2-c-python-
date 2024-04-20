#            0       1       2
people = ['Triet','Minh','Vincent']
print(people)
print(people[2])

#Storing different type of data in a list
items = ['Computer',10,4.5,True,'Mouse',5.6]
print(items)
print(items[2])

#Neg index  -4      -3       -2        -1 
#Pos index   0       1        2         3
fruits = ['Apple','Banana','Mango','Watermelon']
print(fruits[2])
print(fruits[-1])

#List slicing
#Neg index  -4      -3       -2        -1 
#Pos index   0       1        2         3
fruits = ['Apple','Banana','Mango','Watermelon']
print(fruits[0:2])
print(fruits[-3:])

#In & not in operator
print('Apple' in fruits)
print('Banana' not in items)

#List function
print(len(fruits))
fruits.insert(1,'Pineapple')
fruits.append(['Guava','Apricot']) #add the whole list
fruits.extend(['Guava','Apricot'])#add the item
fruits.remove('Mango')
'''fruits.pop()#delete the last item in list'''
print(fruits)
print(fruits.index('Watermelon'))
items.append('Keyboard')
print(items)
scores = [1,2,3,7,10,100]
print(max(scores))
print(min(scores))

a = [1,2,3]
b = [4,5,6]
print(a + b)
print(a*3)

#Nesting list
a = [1,2,3,4,5,6,7,8]
b = [1,2,[3,4,5],6,7,8,[9,10]]
print(b[2])
print(b[2][1])

#Mutability of list
a = [1,2,3]
b = [1,2,3]
a[1] = 100
a[2] = 300
b[0:4] = [10,20,30]
print(a)
print(b)

#Tuples of lists
Fruits = ('Apple','Banana','Mango','Watermelon')
#Fruits[0] = 'peach' #error: because tuple can not be change
#print(Fruits[1])

'''#Searching items in a list
products = ['phone','tablet','laptop','journal']
#item = input('Enter product to search: ')
#print(item in products)
#Task 2
#asking user to remove a product
remove_item = input('Enter product to remove from the list: ')
products.remove(remove_item)
#Displying the entire list after removing item
print(f'Current list of items:{products}')
#Task 3
#asking user to add a product
add_item = input('Enter product to add to the list: ')
products.append(add_item)
#Displying the entire list after adding item
print(f'Current list of items:{products}')'''

#Searching items in a list
products = ['phone','tablet','laptop','journal']
print(f'Current list of items:{products}')
add_item = input('Enter product to add to the list: ')
add_after = input(f'After which product do you want to to place {add_item} ')
index = products.index(add_after)
products.insert(index+1, add_item)
print(f'Current list of items:{products}')