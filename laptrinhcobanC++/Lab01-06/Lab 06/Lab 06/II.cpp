#include <iostream>
#include <conio.h>
#include <stdio.h>
#define MAXROW 100
#define MAXCOL 100
using namespace std;
void NhapM2C(int a[][MAXCOL], int n)
{
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            cout << "Nhap phan tu dong " << i << " cot " << j << endl;
            cin >> a[i][j];
        }
    }
}

void XuatM2C(int a[][MAXCOL], int n)
{
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            cout << a[i][j] << " ";
        }
        cout << endl;
    }
}
void XuatDuongCheoPhu(int a[][MAXCOL], int n)
{
	for (int i = 0; i < n; i++) {
		cout << a[i][n - i - 1] << " ";
	}
}
void XuatTamGiacTren(int a[][MAXCOL], int n)
{
    for (int i = 0; i < n; i++) {
        for (int j = i; j < n; j++) {
            cout << a[i][j] << " ";
        }
    }
}
void TimCotTongLonNhat(int a[][MAXCOL], int n)
{
    int maxCol = 0;
    int maxSum = 0;
    // Tính tổng các phần tử trong cột đầu tiên
    for (int i = 0; i < n; i++) {
        maxSum += a[i][0];
    }
    // Duyệt qua từng cột, tìm cột có tổng lớn nhất
    for (int j = 1; j < n; j++) {
        int sum = 0;
        for (int i = 0; i < n; i++) {
            sum += a[i][j];
        }
        if (sum > maxSum) {
            maxSum = sum;
            maxCol = j;
        }
    }
    cout << maxCol << endl;
    cout << "Tong la: ";
    cout << maxSum << endl;
}
void DongCoTongChanNhoNhat(int a[][MAXCOL], int n)
{
    int minRow = 0;
    int minSum = 0;
    //Tong phan tu dong dau tien
    for (int j = 0; j < n; j++) {
        if (a[0][j] % 2 == 0) {
            minSum += a[0][j];
        }
    }
    //Duyet tung dong
    for (int i = 1; i < n; i++) {
        int sum = 0;
        for (int j = 0; j < n; j++) {
            if (a[i][j] % 2 == 0) {
                sum += a[i][j];
            }
        }
        if (sum < minSum) {
            minSum = sum;
            minRow = i;
        }
    }
    cout << minRow << endl;
    cout << "Tong la: ";
    cout << minSum << endl;
}
int TongDuongCheoChinh(int a[][MAXCOL], int n)
{
    int sum = 0;
    for (int i = 0; i < n; i++) {
        sum += a[i][i];
    }
    return sum;
}
int TongPhanTuChanTamGiacTren(int a[][MAXCOL], int n)
{
    int sum = 0;
    for (int i = 0; i < n; i++) {
        for (int j = i; j < n; j++) {
            if (a[i][j] % 2 == 0) {
                sum += a[i][j];
            }
        }
    }
    return sum;
}
int TongPhanTuLeTamGiacDuoi(int a[][MAXCOL], int n)
{
    int sum = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j <= i; j++) {
            if (a[i][j] % 2 != 0) {
                sum += a[i][j];
            }
        }
    }
    return sum;
}
void XuatCacPhanTuDuongBien(int a[][MAXCOL], int n)
{
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            // kiem tra xem phan tu co nam tren duong bien hay khong
            if (i == 0 || j == 0 || i == n - 1 || j == n - 1) {
                cout << a[i][j] << " ";
            }
            else {
                cout << "  ";
            }
        }
        cout << endl;
    }
}
int main()
{
    int a[MAXROW][MAXCOL];
    int n;
    cout << "Nhap kich thuoc ma tran vuong: ";
    cin >> n;
    NhapM2C(a, n);
    XuatM2C(a, n);
    int choice;
    do {
        cout << "Menu:" << endl;
        cout << "1. Xuat cac phan tu tren duong cheo phu: " << endl;
        cout << "2. Xuat cac phan tu tam giac tren: " << endl;
        cout << "3. Xuat cot co tong lon nhat: " << endl;
        cout << "4. Xuat dong co tong so chan nho nhat: " << endl;
        cout << "5. Xuat tong phan tu duong cheo chinh: " << endl;
        cout << "6. Xuat tong phan tu chan cua tam giac tren: " << endl;
        cout << "7. Xuat tong phan tu le cua tam giac duoi: " << endl;
        cout << "8. Xuat cac phan tu o duong bien: " << endl;
        cout << "0. Thoat" << endl;
        cout << "Nhap lua chon: ";
        cin >> choice;
        switch (choice) {
        case 1:
            cout << "Cac phan tu tren duong cheo phu la: ";
            XuatDuongCheoPhu(a, n);
            cout << endl;
            break;
        case 2:
            cout << "Cac phan tu tam giac tren la: ";
            XuatTamGiacTren(a, n);
            cout << endl;
            break;
        case 3:
            cout << "Cot co tong lon nhat la cot thu: ";
            TimCotTongLonNhat(a, n);
            break;
        case 4:
            cout << "Dong co tong so chan nho nhat: ";
            DongCoTongChanNhoNhat(a, n);
            break;
        case 5:
            cout << "Tong phan tu tren duong cheo chinh la: " << TongDuongCheoChinh(a, n)<<endl;
            break;
        case 6:
            cout << "Tong cac phan tu chan cua tam giac tren: " << TongPhanTuChanTamGiacTren(a, n) << endl;
            break;
        case 7:
            cout << "Tong cac phan tu le cua tam giac duoi: ";
            cout << TongPhanTuLeTamGiacDuoi(a, n) << endl;
            break;
        case 8:
            cout << "Cac phan tu tren duong bien: "<<endl;
            XuatCacPhanTuDuongBien(a, n);
            break;
        case 0:
            cout << "Tam biet!";
            break;
        default:
            cout << "Lua chon khong hop le!";
            break;
        }
    } while (choice != 0);
    return 0;
}