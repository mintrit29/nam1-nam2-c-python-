import math
class Circle:
    def __init__(self, r=0):
        self.r = r
    def nhap(self):
        self.r = float(input('Nhập bán kính r: '))
    def tinh_chu_vi(self):
        return 2 * math.pi * self.r
    def tinh_dien_tich(self):
        return math.pi * self.r ** 2
def main():
    circle = Circle()
    circle.nhap()
    chu_vi = circle.tinh_chu_vi()
    dien_tich = circle.tinh_dien_tich()
    print(f'Chu vi của bán kính r = {chu_vi}')
    print(f'Diện tích của bán kính r = {dien_tich}')

if __name__ == "__main__":
    main()