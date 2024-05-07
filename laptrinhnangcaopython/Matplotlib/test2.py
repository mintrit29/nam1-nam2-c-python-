import matplotlib.pyplot as plt
plt.barh([1,3,5,7,9],[100,200,300,400,500],label='Le',color='y')
plt.barh([2,4,6,8,10],[50,60,20,50,60],label='Chan',color='c')

plt.legend()
plt.xlabel('bar number')
plt.ylabel('bar height')
plt.title('Ve hai bieu do')
plt.show()