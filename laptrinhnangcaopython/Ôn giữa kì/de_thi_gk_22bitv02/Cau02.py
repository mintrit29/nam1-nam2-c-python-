L = [
    "doublemint,1.5,10",
    "mentos,0.7,20",
    "oreo,2.8,5",
    "chupachups,0.2,30"
]
#a)
D = {}
for item in L:
    #print(item)
    arr = item.split(",")
    #print(arr)
    D[arr[0]] = int(arr[2])
print(D)
#b)
print(D.items())
LL = sorted(D.items(), key= lambda kv: (kv[1], kv[0]))
#LL = sorted(D.items(), key= lambda kv: kv[1])
print(LL)
#c)
S = 0
for item in D:
    S += D[item]
print('S = ', S)