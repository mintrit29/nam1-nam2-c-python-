import math
class Circle:
    radius: int = 0

    def __init__(self, rad) -> None:
        self.radius = rad

    def calculate_area(self) -> float:
        return math.pi * self.radius**2
    
    def calculate_perimeter(self) -> float:
        return 2 * math.pi * self.radius
    
    def __str__(self) -> str:
        return f'Circle R = {self.radius}. S = {self.calculate_area()}, P = {self.calculate_perimeter()}'
    
class Rectangle:
    def __init__(self, width, height):
        self.width = width
        self.height = height

    def calculate_area(self):
        return self.width * self.height

    def calculate_perimeter(self):
        return 2 * (self.width + self.height)

    def __str__(self):
        return f'Rectangle W = {self.width}, H = {self.height}. S = {self.calculate_area()}, P = {self.calculate_perimeter()}'
    
#Demo
if __name__ == '__main__':
    #C1 = Circle(5)
    #C2 = Circle(9)
    #print(C1)
    #print(C2)

    shapes = []
    shapes.append(Circle(71))
    shapes.append(Circle(19))

    for shape in shapes:
        print(shape)

if __name__ == '__main__':
    shapes = []
    shapes.append(Rectangle(3, 4))
    shapes.append(Rectangle(5, 7))

    for shape in shapes:
        print(shape)
