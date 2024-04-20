class Point2D():
    def __init__(self,x=0,y=0):
        self.x = x
        self.y = y
    def str(self):
        return f'({self.x}, {self.y})'
    def input(self):
        self.x = float(input('Enter x: '))
        self.y = float(input('Enter y: '))
    def calculate_distance(self,other_point):
        return ((self.x - other_point.x) ** 2 + (self.y - other_point.y) ** 2) ** 0.5

def main():
    p1 = Point2D()
    p1.input()
    p2 = Point2D()
    p2.input()
    print(p1.str())
    print(p2.str())
    print(p1.calculate_distance(p2))

if __name__ == '__main__':
    main()