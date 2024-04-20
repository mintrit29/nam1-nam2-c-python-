#Bai 3 Check if it is an Armstrong number
def is_armstrong_number(number):
    # Convert the number to a string to find its length (number of digits)
    num_str = str(number)
    num_digits = len(num_str)
    
    # Calculate the sum of each digit raised to the power of the number of digits
    armstrong_sum = sum(int(digit) ** num_digits for digit in num_str)
    
    # Check if the sum is equal to the original number
    return armstrong_sum == number


# Test 
number = int(input("Nhap so can kiem tra: "))
if is_armstrong_number(number):
    print(number, "Day la so Armstrong.")
else:
    print(number, "Day khong phai so Armstrong.")