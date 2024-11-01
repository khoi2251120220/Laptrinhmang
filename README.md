# Phần Mềm Đấu Giá Bảng Số Xe

Dự án phần mềm đấu giá bảng số xe là một ứng dụng client-server cho phép người dùng tham gia đấu giá biển số xe trực tuyến. Dự án được phát triển bằng C# với mục đích học tập về lập trình mạng.

## Cấu Trúc Dự Án

```
Solution/
├── Server/               # Ứng dụng máy chủ
│   ├── Program.cs       # Entry point của server
│   ├── Services/        # Business logic
│   │   └── AuctionService.cs
│   ├── Data/           # Database context và migrations
│   │   └── DatabaseContext.cs
│   └── .env            # Cấu hình môi trường
├── Shared/               # Thư viện chia sẻ
│   ├── Models/         # Model classes
│   │   ├── Auction.cs
│   │   ├── Bid.cs
│   │   └── User.cs
│   └── Interfaces/     # Interfaces
│       └── IAuctionService.cs
└── Client/             # WinForms client
```

## Yêu Cầu Hệ Thống

- .NET 8.0 hoặc cao hơn
- MySQL

## Cài Đặt

Yêu cầu sửa đổi chuỗi kết nối trong file `Server/Data/DatabaseContext.cs` để kết nối với cơ sở dữ liệu MySQL.

## Chạy Ứng Dụng

1. Chạy Server:

```bash
cd Server
dotnet run
```

2. Chạy Client (trong terminal khác):

```bash
cd Client
dotnet run
```

## Network Protocol

- Sử dụng TCP Socket cho giao tiếp client-server
- Format message: `command|param1|param2|...`

## Acknowledgments

- Đây là dự án phục vụ mục đích học tập
- Cảm ơn giảng viên: Bùi Dương Thế đã hướng dẫn
