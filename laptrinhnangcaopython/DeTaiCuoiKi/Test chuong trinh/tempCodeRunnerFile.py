def menu():
    conn = sqlite3.connect('bongda.db')
    cursor = conn.cursor()

    while True:
        print("\nChọn chức năng:")
        print("1. Tạo đội bóng mới")
        print("2. Vào đội bóng đã có")
        print("3. Thoát")
        lua_chon = input("Nhập lựa chọn của bạn: ")

        if lua_chon == '1':
            them_doi_bong = ThemDoiBong()
            them_doi_bong.nhap_thong_tin()
            conn.commit()  # Lưu thay đổi vào database
            conn.close()  # Đóng kết nối
        elif lua_chon == '2':
            hien_thi_doi_bong = HienThiDoiBong()
            hien_thi_doi_bong.hien_thi()
            ma_db = input("Nhập mã đội bóng để vào: ")
            cursor.execute("SELECT TenDoi FROM DoiBong WHERE MaDB = ?", (ma_db,))
            ten_db = cursor.fetchone()
            if ten_db:
                ten_db = ten_db[0]
                while True:
                    print("\nChọn chức năng:")
                    print("1. Thêm cầu thủ")
                    print("2. Xóa cầu thủ")
                    print("3. Sửa cầu thủ")
                    print("4. Hiển thị cầu thủ")
                    print("5. Tìm kiếm cầu thủ")
                    print("6. Sắp xếp cầu thủ")
                    print("7. Xem tổng giá trị đội bóng")  # Thêm chức năng xem tổng giá trị
                    print("8. Quay lại menu chính")
                    lua_chon = input("Nhập lựa chọn của bạn: ")

                    if lua_chon == '1':
                        them_cau_thu = ThemCauThu(ma_db, ten_db)
                        them_cau_thu.nhap_thong_tin()
                    elif lua_chon == '2':
                        xoa_cau_thu = XoaCauThu(ma_db)
                        xoa_cau_thu.xoa_cau_thu()
                    elif lua_chon == '3':
                        sua_cau_thu = SuaCauThu(ma_db)
                        sua_cau_thu.sua_cau_thu()
                    elif lua_chon == '4':
                        hien_thi_cau_thu = HienThiCauThu(ma_db)
                        hien_thi_cau_thu.hien_thi()
                    elif lua_chon == '5':
                        tim_kiem_cau_thu = TimKiemCauThu(ma_db)
                        tim_kiem_cau_thu.tim_kiem()
                    elif lua_chon == '6':
                        sap_xep_cau_thu = SapXepCauThu(ma_db)
                        sap_xep_cau_thu.sap_xep()
                    elif lua_chon == '7':  # Xem tổng giá trị đội bóng
                        tong_gia_tri = tinh_tong_gia_tri_doi_bong(ma_db)
                        print(f"Tổng giá trị đội bóng: {tong_gia_tri}")
                    elif lua_chon == '8':
                        break
                    else:
                        print("Lựa chọn không hợp lệ.")
            else:
                print("Không tìm thấy đội bóng với mã đó.")
        elif lua_chon == '3':
            break
        else:
            print("Lựa chọn không hợp lệ.")

    conn.close()

menu()