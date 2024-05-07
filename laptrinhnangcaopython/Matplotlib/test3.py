import matplotlib.pyplot as plt
D={'CNTT':500,'Toan':310,'Hoa':150,'Sinh':280,'Giao Duc':340}

plt.pie(D.values(), labels=D.keys(),autopct='%1.1f%%',shadow=True,startangle=90)

plt.axis('equal')
plt.show()