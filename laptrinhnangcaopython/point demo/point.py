#Point.py
class Point:
    x = 0
    y = 0

    def output(self):
        print(f'{self.x} {self.y}')

    def calculate_distance(self, other_point):
        return ((self.x - other_point.x) ** 2 + (self.y - other_point.y) ** 2) ** 0.5
    
    #Ham khoi tao (constructor): ten __init__
    def __init__(self, tx, ty):
        self.x = tx
        self.y = ty

    def __str__(self):
        return f'({self.x}, {self.y})'