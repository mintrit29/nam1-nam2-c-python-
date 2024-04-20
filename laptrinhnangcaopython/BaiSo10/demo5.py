import math

def distance(x1, y1, x2, y2):
    return math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2)

# Ví dụ:
x1, y1 = 1, 2
x2, y2 = 3, 4
print("Khoảng cách giữa hai điểm:", distance(x1, y1, x2, y2))
