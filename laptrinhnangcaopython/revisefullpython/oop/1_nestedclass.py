class Car:
    def __init__(self,brand):
        self.brand = brand
        self.steering_object = self.Steering()

    @staticmethod
    def drive():
        print('Drive')

    class Steering:
        @staticmethod
        def rotate():
            print('Rotate')

car = Car('Audi')
car.drive()

steering = car.steering_object
steering.rotate()