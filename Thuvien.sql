CREATE DATABASE Thuvien
GO
USE Thuvien
GO
CREATE TABLE THELOAI
(
MaTL NVARCHAR(20) PRIMARY KEY,
TenTL NVARCHAR (200)
)
GO
CREATE TABLE SACH
(
MaSach NVARCHAR(20) PRIMARY KEY,
TenSach NVARCHAR (200),
Theloai NVARCHAR (200),
Tacgia NVARCHAR (200),
NamXB INT,
MaTL NVARCHAR(20) ,
FOREIGN KEY (MaTL) REFERENCES THELOAI(MaTL)
)
GO
CREATE TABLE THESV
(
MaSV NVARCHAR(20) PRIMARY KEY,
TenSV NVARCHAR (200),
Lop NVARCHAR (200),
Khoa INT,
Namsinh INT,
SDT NVARCHAR (11),
Quequan TEXT,
)
GO
CREATE TABLE MUONTRA
(
MaMuon NVARCHAR(20) PRIMARY KEY,
TenSV NVARCHAR (200),
TenSach NVARCHAR (200),
TrangThai BIT,
Ngaymuon NVARCHAR (100),
Ngaytra NVARCHAR (100),
)
GO
INSERT INTO THELOAI(MaTL,TenTL)
VALUES
('TL1','Trinh tham'),
('TL2','Phieu luu'),
('TL3','Ngon tinh'),
('TL4','Hai huoc'),
('TL5','Xuyen khong'),
('TL6','Kinh doanh');
GO 
SELECT * FROM THELOAI;
GO
INSERT INTO SACH(MaSach ,TenSach, Theloai, Tacgia, NamXB, MaTL)
VALUES
('S1','Sherlock Holmes', 'Trinh tham', 'Arthur Conan Doyle','1887','TL1'),
('S2','The Call of the Wild', 'Phieu luu', 'Jack London', '1906', 'TL2' );
GO
SELECT * FROM SACH;
GO
INSERT INTO THESV(MaSV,TenSV, Lop, Khoa, Namsinh, SDT, Quequan)
VALUES
('SV1','Le Huyen Huy','Cong nghe thong tin','25','2004','0917502115','Ly Van Lam, Ca Mau'),
('SV2','Le Van Tu','Luat kinh te','24','2003','0946164233','Phuong 2, Ca Mau');
GO 
SELECT * FROM THESV;
GO
INSERT INTO MUONTRA(MaMuon, TenSV, TenSach, TrangThai, Ngaymuon, Ngaytra)
VALUES
('M1','Le Huyen Huy','Sherlock Holmes','0','20/12/2023','1/1/2024'),
('M2','Le Van Tu','The Call of the Wild','1','20/10/2023','1/11/2023');
GO
SELECT * FROM MUONTRA;