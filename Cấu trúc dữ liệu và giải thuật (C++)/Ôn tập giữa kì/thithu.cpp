#include <stdio.h>
#include <iostream>
#include <string>
using namespace std;
//Cau1a
struct TRANSACTION
{
    int OrderID;
    string ProductName;
    float UnitPrice;
    int Quantity;
    float Discount;
};

struct node
{
    TRANSACTION data;
    node *next;
};

node *makeNode(TRANSACTION transaction)
{
    node *newNode = new node();
    newNode->data = transaction;
    newNode->next = NULL;
    return newNode;
}
void duyet(node *head)
{
    while (head != NULL)
    {
        cout <<"["<<head->data.OrderID << " " << head->data.ProductName << " " << head->data.UnitPrice << " " << head->data.Quantity << " " << head->data.Discount << "]" << endl;
        head = head->next;
    }
}
//Cau1b
void AddTransaction(node *&head, TRANSACTION transaction)
{
    node *newNode = makeNode(transaction);
    node *temp = head;
    if (head == NULL)
    {
        head = newNode;
        return;
    }
    while (temp->next != NULL)
    {
        temp = temp->next;
    }
    temp->next = newNode;
}
//Cau2a,b
void PrintTransactions(node *head)
{
    if (head == NULL)
    {
        cout << "Danh sách rỗng!" << endl;
        return;
    }

    cout << "Danh sách giao dịch:" << endl;
    cout << "--------------------" << endl;
    int sum = 1;
    while (head != NULL)
    {
        cout << "Mã giao dịch: " << head->data.OrderID << endl;
        cout << "Tên sản phẩm: " << head->data.ProductName << endl;
        cout << "Đơn giá: " << head->data.UnitPrice << endl;
        cout << "Số lượng: " << head->data.Quantity << endl;
        cout << "Tỷ lệ giảm giá: " << head->data.Discount << "%" << endl;
        cout << "--------------------" << endl;
        head = head->next;
        cout << "Tổng số giao dịch có trong dslk: " << sum++ << endl;
    }
}

void FindTransactions(node *head, string x)
{
    node *temp = head;
    bool found = false;
    while (temp != NULL)
    {
        if (temp->data.ProductName == x)
        {
            found = true;
            cout << "Mã giao dịch: " << temp->data.OrderID << endl;
            cout << "Tên sản phẩm: " << temp->data.ProductName << endl;
            cout << "Đơn giá: " << temp->data.UnitPrice << endl;
            cout << "Số lượng: " << temp->data.Quantity << endl;
            cout << "Tỷ lệ giảm giá: " << temp->data.Discount << "%" << endl;
            cout << "--------------------" << endl;
        }
        temp = temp->next;
    }
    if (!found)
    {
        cout << "Khong co san pham can tim." << endl;
    }
}

//Cau4a
int GetSubTotal(node *head){
    float subTotal = 0;
    while (head != NULL)
    {
        subTotal = (head->data.UnitPrice * head->data.Quantity) * (100 - head->data.Discount);
        head = head->next;
    }
    return subTotal;
}
//Cau4b
int GetTotal(node *head){
    float sum = 0;
    if (head == NULL)
    {
        cout << "Rỗng!" << endl;
    }

    while (head != NULL)
    {
        float subTotal = GetSubTotal(head);
        sum += subTotal;
        head = head->next;
    }
        return sum;
}

//Cau5a
node *InverseList(node *head)
{
    node *prev = NULL;
    node *current = head;
    node *next = NULL;
    while (current != NULL)
    {
        next = current->next;
        current->next = prev;
        prev = current;
        current = next;
    }
    head = prev;
    return head;
}

// Cau5b
void PrintTransactionList(node *head)
{
    cout << "Danh sách giao dịch theo thứ tự ngược lại:" << endl;
    cout << "-----------------------------------------" << endl;
    duyet(head); 
}

int main()
{
    node *head = NULL;
    int choice;
    do
    {
        cout << "Nhap vao lua chon cua ban: " << endl;
        cout << "1. Them giao dich" << endl;
        cout << "2. In ra giao dich" << endl;
        cout << "3. Duyet danh sach" << endl;
        cout << "4. So tien cua giao dich" << endl;
        cout << "5. Tổng tiền của tất cả các giao dịch" << endl;
        cout << "6. Tìm thông tin giao dịch của sản phẩm" << endl;
        cout << "7. Đảo ngược danh sách" << endl;
        cout << "0. Thoat" << endl;
        cin >> choice;
        switch (choice)
        {
        case 1:
        {
            TRANSACTION transaction;
            cout << "Nhap ma giao dich: ";
            cin >> transaction.OrderID;
            cout << "Nhap ten san pham: ";
            cin >> transaction.ProductName;
            cout << "Nhap don gia: ";
            cin >> transaction.UnitPrice;
            cout << "Nhap so luong: ";
            cin >> transaction.Quantity;
            cout << "Nhap giam gia: ";
            cin >> transaction.Discount;
            AddTransaction(head, transaction);
            break;
        }
        case 2:
        {
            PrintTransactions(head);
            break;
        }
        case 3:
        {
            duyet(head);
            break;
        }
        case 4:
        {
            cout << "Tổng tiền của giao dịch là: " << GetSubTotal(head) << endl;
            break;
        }
        case 5:
        {
            cout << "Tổng tiền của toàn bộ giao dịch là: " << GetTotal(head) << endl;
            break;
        }
        case 6:
        {
            string x;
            cout << "Nhap ten san pham: ";
            cin >> x;
            FindTransactions(head,x);
        }
        case 7:
        {
            head = InverseList(head);
            PrintTransactionList(head);
            break;
        }
        }
    } while (choice != 0);
}
