#include <iostream>
#include<stdio.h>
#include<time.h>
#include<cstdlib>
#include<math.h>
using namespace std;
#define MAXROW 100 //số dòng tối đa
#define MAXCOL 100 //số cột tối đa
void NhapM2CRandom(int a[][MAXCOL], int &m, int &n)
{
	for (int i = 0; i < m; i++) {
		for (int j = 0; j < n; j++) {
			a[i][j] = rand() % 100;
		}
	}
}
void XuatM2C(int a[][MAXCOL], int m, int n)
{
	for (int i = 0; i < m; i++) {
		for (int j = 0; j < n; j++) {
			cout << a[i][j] << " ";
		}
		cout << endl;
	}
}
void TimX(int a[][100], int x, int m, int n)
{
	bool found = false; // biến này để lưu trạng thái tìm thấy hay không
	// Duyệt ma trận và tìm giá trị x
	for (int i = 0; i < m; i++) {
		for (int j = 0; j < n; j++) {
			if (a[i][j] == x) {
				found = true; // tìm thấy x
				cout << "Tim thay X o a[" << i << "][" << j << "]" << endl;
			}
		}
	}
	// Nếu không tìm thấy giá trị x thì thông báo không tìm thấy
	if (!found) {
		cout << "Khong tim thay X" << endl;
	}
}
int TimMaxDongK(int a[][MAXCOL], int n, int k) {
	int max = a[k][0]; // Giả sử phần tử đầu tiên của dòng k là max
	for (int j = 1; j < n; j++) { // Duyệt qua các phần tử khác của dòng k
		if (a[k][j] > max) {
			max = a[k][j]; // Nếu phần tử j của dòng k lớn hơn max, cập nhật max
		}
	}
	return max;
}
void DemSoDuong(int a[][MAXCOL], int m, int n)
{
	int count = 0;
	bool found = false;
	for (int i = 0; i < m; i++) {
		for (int j = 0; j < n; j++) {
			if (a[i][j] > 0) {
				found = true;
				count++;
			}
		}
	}
	if (found) {
		cout << "Co " << count << " phan tu duong trong ma tran" << endl;
	}
	else {
		cout << "Ma tran khong co phan tu duong nao" << endl;
	}
}
int main()
{
	int a[MAXROW][MAXCOL];
	int m, n;
	cout << "Nhap vao so dong va cot\n";
	cin >> m >> n;
	int choice;
	do {
		cout << "[[Menu]]\n";
		cout << "Chon so cua cong cu can dung:\n";
		cout << "1. Tao gia tri ngau nhien cho ma tran:\n";
		cout << "2. Xuat gia tri ngau nhien:\n";
		cout << "3. Tim gia tri X trong ma tran:\n";
		cout << "4. Tim Max cua dong K:\n";
		cout << "5. Dem so phan tu duong co trong ma tran:\n";
		cout << "0. De thoat.\n";
		cin >> choice;
		switch (choice) {
		case 1:
			NhapM2CRandom(a, m, n);
			cout << "Da tao ngau nhien gia tri cho cac phan tu cua ma tran" << endl;
			break;
		case 2:
			cout << "Ma tran ban vua tao: " << endl;
			XuatM2C(a, m, n);
			break;
		case 3:
			int x;
			cout << "Nhap vao gia tri can tim: ";
			cin >> x;
			TimX(a, x, m, n);
			break;
		case 4:
			int k;
			cout << "Nhap vao so dong k can tim MAX ";
			cin >> k;
			TimMaxDongK(a, n, k);
			break;
		case 5:
			DemSoDuong(a, m, n);
			break;
		case 0:
			cout << "Thoat.\n";
			break;
		default:
			cout << "Lua chon khong hop le" << endl;
			break;
	}
	} while (choice != 0);
}