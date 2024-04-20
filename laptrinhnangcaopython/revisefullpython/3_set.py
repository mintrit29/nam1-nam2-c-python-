#Sets
numbers = set([1,2,3,4,5,6])
print(numbers)
#easy way
numbers = {1,2,3,4,5,6,6,5,4,3}#each set has unique item, cannot be duplicate 
print(numbers)
numbers = {5,3,2,5,1,6,3,4,7}#set is unordered, we can not search through index
print(numbers)
#empty set
names = {'John','Rob','Mike','John'}
print(names)
s = set() #empty set
print(type(s))

#set operation
s = {'John','Rob','Mike'}
print('John' in s)#check element

seta = {1,2,3,4,5}
setb = {4,5,6,7,8}
print(seta|setb)
print(seta&setb)
print(seta-setb)
print(setb-seta)
print(setb^seta)

#Add And Remove Set
seta = {1,2,3,4,5}
seta.add(10)
seta.remove(1)
seta.discard(3)#remove item without cause error
seta.pop()#random remove
seta.clear()#remove the whole set
print(seta)