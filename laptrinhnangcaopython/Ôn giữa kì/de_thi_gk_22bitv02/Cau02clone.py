L = [
"doublemint,1.5,10",
"mentos,0.7,20",
"oreo,2.8,5",
"chupachups,0.2,30"
]

#a
D = {}
for item in L:
    arr = item.split(",")
    D[arr[0]]=int(arr[2])
print(D)
#b
def min_value(D):
    sorted_list = sorted(D.items(),key=lambda kv: kv[1])
    return sorted_list[0][0]
print(min_value(D))
#c
def sum_item(D):
    sum = 0
    for item in D:
        sum = sum + D[item]
    return sum
print(sum_item(D))