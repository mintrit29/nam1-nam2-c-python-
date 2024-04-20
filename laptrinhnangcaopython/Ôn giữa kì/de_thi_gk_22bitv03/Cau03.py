L = [
  { 'ten': 'CNTT', 'soluong': 700, 'nam': '2012'},
  { 'ten': 'LY', 'soluong': 300, 'nam': '2008'},
  { 'ten': 'HOA', 'soluong': 200, 'nam': '2010'},
  { 'ten': 'TOAN', 'soluong': 500, 'nam': '2000'}
]

# Sắp xếp theo số lượng sinh viên tăng dần
D=[]
SV_sorted = sorted(L, key=lambda x: x['soluong'])
for item in SV_sorted:
  D.append(item['soluong'])
print(D)

#b
E=[]
SV_sorted = sorted(L, key=lambda x: x['nam'],reverse=True)
for item in SV_sorted:
  E.append(item['ten'])
  '''str = ','.join(E)
print(str)'''
print(E[-1])

#c
V=[]
SV_sorted = sorted(L, key=lambda x: x['soluong'],reverse=True)
for item in SV_sorted:
  if item['soluong'] > 200:
    V.append(item['ten'])
    str = ','.join(V)
print(str)
