#include <iostream>
#include <math.h>
#include <stdlib.h>
using namespace std;
#define MAXROW 100
#define MAXCOL 100
void NhapMTV(int a[][MAXCOL], int& n)
{
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			cout << "Gia tri cua a[" << i << "][" << j << "]: " << endl;
			cin >> a[i][j];
		}
	}
}
void NhapMTVRandom(int a[][MAXCOL], int& n)
{
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			a[i][j] = rand() % 100;
		}
	}
}
void XuatMTV(int a[][MAXCOL], int n)
{
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			cout << a[i][j] << " ";
		}
		cout << endl;
	}
}
int TongDuongCheoChinh(int a[][MAXCOL], int n)
{
	int s = 0;
	for (int i = 0; i < n; i++) {
		cout << a[i][i] << " ";
		s += a[i][i];
	}
	return s;
}
int DemDCPChinhPhuong(int a[][MAXCOL], int n)
{
	int dem = 0;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			int sqrt_a = sqrt(a[i][n - i - 1]);
			if (sqrt_a * sqrt_a == a[i][j]) {
				dem++;
			}
		}
	}
	return dem;
}
bool KiemTraMaTranDuong(int a[][MAXCOL], int n)
{
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			if (a[i][j] < 0) {
				return false;
			}
		}
	}
	return true;
}
bool DuongCheoChinhToanSo1(int a[][MAXCOL], int n)
{
	for (int i = 0; i < n; i++) {
		if (a[i][i] != 1) {
			return false;
		}
	}
	return true;
}
bool KiemTraMaTranDoiXung(int a[][MAXCOL], int n)
{
	for (int i = 0; i < n; i++) {
		for (int j = i; j < n; j++) { //chỉ cần duyệt từ j=i để tránh so sánh 2 lần
			if (a[i][j] != a[j][i]) {
				return false;
			}
		}
	}
	return true;
}
int main()
{
	int a[MAXROW][MAXCOL];
	int n;
	cout << "Nhap vao cap cua ma tran: ";
	cin >> n;
	int choice;
	do {
		cout << "\nNhap vao lua chon cua ban: " << endl;
		cout << "---MENU---\n";
		cout << "1. MTV Nguoi dung tu nhap\n";
		cout << "2. MTV ngau nhien\n";
		cout << "3. Xuat ma tran\n";
		cout << "4. Tinh tong duong cheo chinh\n";
		cout << "5. Dem so chinh phuong duong cheo phu\n";
		cout << "6. Kiem tra ma tran duong khong\n";
		cout << "7. Kiem tra duong cheo chinh co toan la so 1 khong\n";
		cout << "8. Kiem tra tinh doi xung cua ma tran\n";
		cout << "0. De ket thuc ctrinh\n";
		cin >> choice;
		switch (choice) {
		case 0:
			cout << "Ket thuc ctrinh" << endl;
			break;
		case 1:
			NhapMTV(a, n);
			break;
		case 2:
			NhapMTVRandom(a, n);
			cout << "Da tao ngau nhien phan tu ma tran" << endl;
			break;
		case 3:
			XuatMTV(a, n);
			break;
		case 4:
			cout << "Tong duong cheo chinh la: " << TongDuongCheoChinh(a, n) << endl;
			break;
		case 5:
			cout << "So phan tu chinh phuong duong cheo phu: " << DemDCPChinhPhuong(a, n) << endl;
			break;
		case 6:
			if (KiemTraMaTranDuong(a, n)) {
				cout << "Ma tran duong" << endl;
			}
			else {
				cout << "Ma tran co phan tu am" << endl;
			}
			break;
		case 7:
			if (DuongCheoChinhToanSo1(a, n)) {
				cout << "Duong cheo chinh toan so 1" << endl;
			}
			else {
				cout << "Co phan tu khong bang 1" << endl;
			}
			break;
		case 8:
			if (KiemTraMaTranDoiXung(a, n)) {
				cout << "Ma tran doi xung" << endl;
			}
			else {
				cout << "Ma tran khong doi xung" << endl;
			}
			break;
		default:
			cout << "Nhap sai so roi" << endl;
			break;
		}
	} while (choice != 0);
	return 0;
}
