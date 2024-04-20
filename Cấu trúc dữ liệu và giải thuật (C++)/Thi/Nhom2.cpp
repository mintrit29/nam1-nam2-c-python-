#include <stdio.h>
#include <iostream>
#include <string>
using namespace std;
//test
// Cau1a
struct BOOK
{
    int ID;
    string Title;
    string Author;
    int Year;
    float Cost;
    int Quantity;
};

struct node
{
    BOOK data;
    node *next;
};

node *makeNode(BOOK book)
{
    node *newNode = new node();
    newNode->data = book;
    newNode->next = NULL;
    return newNode;
}

void duyet(node *head)
{
    while (head != NULL)
    {
        cout << "[" << head->data.ID << " " << head->data.Title << " " << head->data.Author << " " << head->data.Year << " " << head->data.Cost << head->data.Quantity << "]" << endl;
        head = head->next;
    }
}

// Cau1b
void AddBook(node *&head, BOOK book)
{
    node *newNode = makeNode(book);
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

// Cau2
void PrintBookList(node *head)
{
    if (head == NULL)
    {
        cout << "Danh sach rong!" << endl;
        return;
    }

    cout << "Danh sach dau sach:" << endl;
    cout << "--------------------" << endl;
    int sum = 1;
    while (head != NULL)
    {
        cout << "Ma sach: " << head->data.ID << endl;
        cout << "Ten sach: " << head->data.Title << endl;
        cout << "Ten tac gia: " << head->data.Author << endl;
        cout << "Nam xuat ban: " << head->data.Year << endl;
        cout << "Gia bia: " << head->data.Cost << endl;
        cout << "So luong: " << head->data.Quantity << endl;
        cout << "--------------------" << endl;
        head = head->next;
        cout << "Tong so dau sach co trong lien ket: " << sum++ << endl;
    }
}

// Cau3
void PrintBooksByAuthor(string author, node *head)
{
    bool found = false;
    node *current = head;

    while (current != NULL)
    {
        if (current->data.Author == author)
        {
            if (!found)
            {
                cout << "Books by author " << author << ":" << endl;
                found = true;
            }
            cout << "  - Book ID: " << current->data.ID << endl;
            cout << "    Title: " << current->data.Title << endl;
            cout << "    Year: " << current->data.Year << endl;
            cout << "    Cost: " << current->data.Cost << endl;
            cout << "    Quantity: " << current->data.Quantity << endl;
            cout << endl;
        }
        current = current->next;
    }

    if (!found)
    {
        cout << "No books found for author " << author << endl;
    }
}

// Cau4
node *inverselist(node *head)
{
    node *newHead = NULL;
    node *current = head;

    while (current != NULL)
    {

        node *newNode = makeNode(current->data);

        newNode->next = newHead;
        newHead = newNode;

        current = current->next;
    }

    return newHead;
}

void freeList(node *head)
{
    while (head != NULL)
    {
        node *temp = head;
        head = head->next;
        delete temp;
    }
}

//cau5
void DeleteBook(node *&head, int year)
{
    if (head == NULL)
    {
        cout << "Danh sach rong!" << endl;
        return;
    }

    node *prev = NULL;
    node *current = head;

    while (current != NULL)
    {
        if (current->data.Year == year)
        {
            // Nếu phần tử cần xóa là phần tử đầu tiên của danh sách
            if (prev == NULL)
            {
                node *temp = current;
                head = current->next;
                current = current->next;
                delete temp;
            }
            else
            {
                node *temp = current;
                prev->next = current->next;
                current = current->next;
                delete temp;
            }
        }
        else
        {
            prev = current;
            current = current->next;
        }
    }
}

// Cau6
float GetTotalPrice(node *head)
{
    float totalPrice = 0.0;
    node *current = head;
    while (current != NULL)
    {
        totalPrice += current->data.Quantity * current->data.Cost;
        current = current->next;
    }

    return totalPrice;
}
//cau7
void PrintAuthorWithMostBooks(node *&head)
{
    if (head == NULL)
    {
        cout << "Danh sach rong!" << endl;
        return;
    }
    string mostBooksAuthor;
    int maxBooks = 0;
    node *current = head;
    while (current != NULL)
    {
        string currentAuthor = current->data.Author;
        int currentAuthorBooks = 0;
        node *innerCurrent = head;
        while (innerCurrent != NULL)
        {
            if (innerCurrent->data.Author == currentAuthor)
            {
                currentAuthorBooks++;
            }
            innerCurrent = innerCurrent->next;
        }
        if (currentAuthorBooks > maxBooks)
        {
            maxBooks = currentAuthorBooks;
            mostBooksAuthor = currentAuthor;
        }

        current = current->next;
    }
    cout << "Tac gia co nhieu dau sach nhat la: " << mostBooksAuthor << " voi " << maxBooks << " dau sach." << endl;
}

// Cau8
int count(node *head)
{
    int count = 0;
    while (head != NULL)
    {
        count++;
        head = head->next;
    }
    return count;
}

void AddBookHead(node *&head, BOOK book)
{
    node *newNode = makeNode(book);
    newNode->next = head;
    head = newNode;
}

void AddBeforeKthBook(node *&head, BOOK book, int k)
{
    int n = count(head);
    if (k < 1 || k > n + 1)
    {
        cout << "Vi tri k khong hop le." << endl;
        return;
    }
    if (k == 1)
    {
        AddBookHead(head, book);
        return;
    }
    node *temp = head;
    for (int i = 1; i < k - 1; i++)
    {
        temp = temp->next;
    }
    node *newNode = makeNode(book);
    newNode->next = temp->next;
    temp->next = newNode;
}

// cau9
void DeleteBeforeKthBook(node *&head, int k)
{
    int n = count(head);
    if (k < 1 || k > n)
    {
        return;
    }

    if (k == 1)
    {

        node *temp = head;
        head = head->next;
        delete temp;
        return;
    }

    node *temp = head;
    for (int i = 1; i <= k - 2; i++)
    {
        temp = temp->next;
    }

    node *delNode = temp->next;
    temp->next = delNode->next;
    delete delNode;
}

// cau10
void ClearAllBooks(node *&head)
{

    while (head != NULL)
    {
        node *temp = head;
        head = head->next;
        delete temp;
    }
    head = NULL;
}

int main()
{
    node *head = NULL;
    int choice;
    do
    {
        cout << "Nhap vao lua chon cua ban: " << endl;
        cout << "1. Them vao sach" << endl;
        cout << "2. In ra dau sach" << endl;
        cout << "3. Tim sach cua tac gia" << endl;
        cout << "4. In ra danh sach dao nguoc" << endl;
        cout << "5. Xoa sach cua nam nhap vao" << endl;
        cout << "6. Tinh tong so tien cua thu vien" << endl;
        cout << "7. Tim tac gia co nhieu dau sach nhat" << endl;
        cout << "8. Them sach vao vi tri thu k" << endl;
        cout << "9. Xoa sach o vi tri thu k" << endl;
        cout << "10. Xoa tat ca sach" << endl;
        cout << "0. Thoat" << endl;
        cin >> choice;
        switch (choice)
        {
        case 1:
        {
            BOOK book;
            cout << "Them vao Ma Sach: ";
            cin >> book.ID;
            cout << "Them vao Ten Sach: ";
            cin >> book.Title;
            cout << "Them vao Ten Tac Gia: ";
            cin >> book.Author;
            cout << "Them vao Nam Xuat Ban: ";
            cin >> book.Year;
            cout << "Them vao gia bia sach: ";
            cin >> book.Cost;
            cout << "Them vao so luong sach: ";
            cin >> book.Quantity;
            AddBook(head, book);
            break;
        }
        case 2:
        {
            PrintBookList(head);
            break;
        }
        case 3:
        {
            cout << "Nhap vao ten tac gia: ";
            string author;
            cin >> author;
            PrintBooksByAuthor(author, head);
            break;
        }
        case 4:
        {

            node *inverseHead = inverselist(head);
            cout << "Danh sach dao nguoc :" << endl;
            cout << "--------------------" << endl;
            PrintBookList(inverseHead);
            freeList(inverseHead);
            break;
        }
        case 5:
        {
            int yearToDelete;
            cout << "Nhap nam muon xoa: ";
            cin >> yearToDelete;
            DeleteBook(head, yearToDelete);
            cout << "Danh sach sau khi xoa cac dau sach duoc xuat ban nam " << yearToDelete << ":" << endl;
            PrintBookList(head);
            break;
        }
        case 6:
        {
            cout << "Tong tien: " << GetTotalPrice(head) << endl;
            break;
        }
        case 7:
        {
            PrintAuthorWithMostBooks(head);
            break;
        }
        case 8:
        {
            BOOK book;
            int k;
            cout << "Nhap vao vi tri thu k: ";
            cin >> k;

            if (k <= 0)
            {
                cout << "Vi tri k phai la so nguyen duong." << endl;
                break;
            }
            cout << "Them vao Ma Sach: ";
            cin >> book.ID;
            cout << "Them vao Ten Sach: ";
            cin >> book.Title;
            cout << "Them vao Ten Tac Gia: ";
            cin >> book.Author;
            cout << "Them vao Nam Xuat Ban: ";
            cin >> book.Year;
            cout << "Them vao gia bia sach: ";
            cin >> book.Cost;
            cout << "Them vao so luong sach: ";
            cin >> book.Quantity;
            AddBeforeKthBook(head, book, k);
            break;
        }
        case 9:
        {
            int k;
            cout << "Nhap vao vi tri thu k: ";
            cin >> k;
            DeleteBeforeKthBook(head, k);
            break;
        }
        case 10:
        {
            ClearAllBooks(head);
            cout << "Danh sach da duoc xoa tat ca sach!" << endl;
            break;
        }
        }
    } while (choice != 0);
}