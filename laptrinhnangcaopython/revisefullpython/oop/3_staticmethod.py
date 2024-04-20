class Circle:
    @staticmethod
    def area(r):
        return 3.14 * r * r
    @staticmethod
    def circumference(r):
        return 2 * 3.14 * r
a = Circle.area(10)
print(a)
c= Circle.circumference(10)
print(c)