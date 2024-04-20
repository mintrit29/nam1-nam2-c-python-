myList = [1, 2, 3, 4, 5, 5, 1]
_max = myList[0]
index_max = 0
for i in range(1, len(myList)):
    if myList[i] > _max:
        _max = myList[i]
        index_max = i
print(index_max)
