#include <stdio.h>
#include <iostream>
using namespace std;

// khai bao mo struct node co data va con tro
struct node
{
    int data;
    node *next;
};

// tao node moi
node *makeNode(int x)
{
    node *newNode = new node();
    newNode->data = x;
    newNode->next = NULL;
    return newNode;
}

void duyet(node *head)
{ // duyet qua danh sach tra ve data
    while (head != NULL)
    {
        cout << head->data << " ";
        head = head->next;
    }
}

int count(node *head)
{ // dem so luong node trong danh sach
    int count = 0;
    while (head != NULL)
    {
        count++;
        head = head->next;
    }
    return count;
}

int countOverlap(node *head, int x)
{
    int count = 0;
    while (head != NULL)
    {
        if (head->data == x)
        {
            count++;
        }
        head = head->next;
    }
    return count;
}

void addHead(node *&head, int x)
{
    node *newNode = makeNode(x);
    newNode->next = head;
    head = newNode;
}

void addTail(node *&head, int x)
{
    node *newNode = makeNode(x);
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

void addAfter(node *&head, int k, int x)
{
    int n = count(head);
    if (k < 1 || k > n + 1)
    {
        return;
    }
    if (k == 1)
    {
        addHead(head, x);
        return;
    }
    node *temp = head;
    for (int i = 1; i <= k - 2; i++)
    {
        temp = temp->next;
    }
    // temp : k -1
    node *newNode = makeNode(x);
    newNode->next = temp->next;
    temp->next = newNode;
}

int sumList(node *head)
{
    int sum = 0;
    node *temp = head;
    while (temp != NULL)
    {
        sum += temp->data;
        temp = temp->next;
    }
    return sum;
}

int maxList(node *head)
{
    int max = INT_MIN; // Khởi tạo giá trị max là giá trị nhỏ nhất có thể của kiểu int
    node *temp = head;
    while (temp != NULL)
    {
        if (temp->data > max)
        {
            max = temp->data;
        }
        temp = temp->next;
    }
    return max;
}

void popHead(node *&head)
{
    if (head == NULL)
        return;
    node *temp = head;
    head = head->next;
    delete temp;
}

void popTail(node *&head)
{
    if (head == NULL)
        return;
    node *temp = head;
    if (temp->next == NULL)
    {
        head = NULL;
        delete temp;
        return;
    }
    while (temp->next->next != NULL)
    {
        temp = temp->next;
    }
    node *last = temp->next; // node cuoi
    temp->next = NULL;
    delete last;
}

void popAfter(node *&head, int k)
{
    int n = count(head);
    if (k < 1 || k > n)
        return;
    if (k == 1)
    {
        popHead(head);
        return;
    }
    else
    {
        node *temp = head;
        for (int i = 1; i <= k - 2; i++)
        {
            temp = temp->next;
        }
        // temp:k - 1
        node *last = temp->next;
        // cho k - 1 => ket noi voi node thu k + 1
        temp->next = last->next;
        delete last;
    }
}

int main()
{
    node *head = NULL;
    int choice;
    do
    {
        cout << "\n---Menu---\n";
        cout << "1. Them vao dau \n";
        cout << "2. Them vao cuoi \n";
        cout << "3. Them vao giua \n";
        cout << "4. Tong gia tri cac phan tu \n";
        cout << "5. Gia tri lon nhat \n";
        cout << "6. Dem so luong phan tu trong DSLK\n";
        cout << "7. Dem so luong phan tu trung voi X trong DSLK\n";
        cout << "8. Xoa Node khoi dau DSLK \n";
        cout << "9. Xoa Node khoi cuoi DSLK \n";
        cout << "10. Xoa Node khoi giua DSLK \n";
        cout << "11. Duyet \n";
        cout << "Nhap vao lua chon cua ban: ";
        cin >> choice;
        switch (choice)
        {
        case 0:
            cout << "Da thoat chuong trinh.\n";
            break;
        case 1:
            int x;
            cout << "Nhap vao x: ";
            cin >> x;
            addHead(head, x);
            break;
        case 2:
            int x2;
            cout << "Nhap vao x: ";
            cin >> x2;
            addTail(head, x2);
            break;
        case 3:
            int x3;
            cout << "Nhap vao x: ";
            cin >> x3;
            int k;
            cout << "Nhap vao k: ";
            cin >> k;
            addAfter(head, k, x3);
            break;
        case 4:
            cout << "Tong cac phan tu la: " << sumList(head) << endl;
            break;
        case 5:
            cout << "Gia tri lon nhat la: " << maxList(head) << endl;
            break;
        case 6:
            cout << "So luong phan tu co trong danh sach la: " << count(head) << endl;
            break;
        case 7:
            int x4;
            cout << "Nhap vao x: ";
            cin >> x4;
            cout << "So luong phan tu trung voi x la: " << countOverlap(head, x4) << endl;
            break;
        case 8:
            popHead(head);
            break;
        case 9:
            popTail(head);
            break;
        case 10:
            int k1;
            cout << "Nhap vao vi tri can xoa" << endl;
            cin >> k1;
            popAfter(head, k1);
            break;
        case 11:
            duyet(head);
            break;
        }
    } while (choice != 0);
}