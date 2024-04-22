#include <iostream>
using namespace std;

int UocSN(int n)
{
    int s = 0;
    for (int i = 1; i <= n; i++)
    {
        if (n % i == 0)
        {
            s += i;
        }
    }
    return s;
}

int soNgay(int month, int year)
{
    if (month == 2)
    {
        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            return 29; // Năm nhuận
        }
        else
        {
            return 28; // Năm không nhuận
        }
    }
    else if (month == 4 || month == 6 || month == 9 || month == 11)
    {
        return 30;
    }
    else
    {
        return 31;
    }
}

void doiVT(float &x, float &y)
{
    float temp = x;
    x = y;
    y = temp;
}

int timBCNN(int a, int b)
{
    int tong = a * b;
    while (a != b)
    {
        if (a > b)
        {
            a -= b;
        }
        else
        {
            b -= a;
        }
    }
    return tong / a;
}

bool soLe(int n)
{
    while (n > 0)
    {
        if ((n % 10) % 2 == 0)
        {
            return false;
        }
        n /= 10;
    }
    return true;
}

int main()
{
    int choice;
    cout << "Nhap so thu tu cua yeu cau muon thuc hien (1-5): ";
    cin >> choice;

    switch (choice)
    {
    case 1: // Tinh tong cac uoc cua so nguyen n
        int n;
        cout << "Nhap mot so nguyen duong: ";
        cin >> n;
        cout << "Tong cac uoc cua " << n << " la: " << UocSN(n) << endl;
        break;
    case 2: // Tinh so ngay trong thang
        int month, year;
        cout << "Nhap thang va nam: ";
        cin >> month >> year;
        cout << "So ngay trong thang " << month << "/" << year << " la: " << soNgay(month, year) << endl;
        break;
    case 3: // Doi cho 2 so thuc
        float x, y;
        cout << "Nhap 2 so thuc x va y: ";
        cin >> x >> y;
        doiVT(x, y);
        cout << "Sau khi doi cho x,y: " << x << ", " << y << endl;
        break;
    case 4: // Tinh BCNN cua 2 so
        int a, b;
        cout << "Nhap vao hai so nguyen duong: ";
        cin >> a >> b;
        cout << "BCNN cua " << a << " va " << b << " la " << timBCNN(a, b) << endl;
        break;
    case 5: // Kiem tra so co toan chu so le hay khong
        int num;
        cout << "Nhap mot so nguyen duong: ";
        cin >> num;
        if (soLe(num))
        {
            cout << num << " co toan chu so le" << endl;
        }
        else
        {
            cout << num << "ko co toan chu so le" << endl;
        }
    }
}