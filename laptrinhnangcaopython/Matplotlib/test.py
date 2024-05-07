import numpy as np
import matplotlib.pyplot as plt
x=np.arange(0,5*np.pi,0.1)
y=np.cos(x)
z=np.sin(x)
plt.plot(x,y,'r+')
plt.plot(x,z,'bo')
plt.xlabel('X')
plt.ylabel('Y')
plt.title('Hàm Cosine va Since trong khoảng 0 đến 5pi')
plt.legend(['Cos(x)','Sin(x)'])
plt.show()