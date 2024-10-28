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
├── Client/              # Console client
│   ├── Program.cs      # Entry point của client
│   └── Services/       # Client services
│       └── AuctionClient.cs
├── Shared/               # Thư viện chia sẻ
│   ├── Models/         # Model classes
│   │   ├── Auction.cs
│   │   ├── Bid.cs
│   │   └── User.cs
│   └── Interfaces/     # Interfaces
│       └── IAuctionService.cs
└── daugia/             # WinForms client (coming soon)
```

## Yêu Cầu Hệ Thống

- .NET 8.0 hoặc cao hơn
- MySQL

## Cài Đặt

1. Tạo database MySQL:

```sql
CREATE DATABASE auction_db;

-- Hoặc có thể dùng table của bạn bằng cách thay đổi connection string trong file .env
```

2. Cấu hình connection string trong file `Server/.env`:

```env
DATABASE_URL=server=localhost;database=auction_db;user=root;password=your_password

```

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

## Tính Năng

### Hiện tại

- Đăng ký và đăng nhập người dùng
- Xem danh sách các cuộc đấu giá đang diễn ra
- Đặt giá cho một cuộc đấu giá
- Xem lịch sử đấu giá
- Tự động khởi tạo dữ liệu mẫu

### Sắp tới

- [ ] Thông báo realtime khi có người đặt giá mới
- [ ] Tự động đóng đấu giá khi hết thời gian
- [ ] Xác thực email
- [ ] Quản lý profile người dùng

## Kiến Trúc Hệ Thống

### Network Protocol

- Sử dụng TCP Socket cho giao tiếp client-server
- Format message: `command|param1|param2|...`
- JSON serialization cho dữ liệu phức tạp

### Database Schema

```sql
users
- id (INT, PK)
- username (VARCHAR)
- password (VARCHAR)
- email (VARCHAR)

auctions
- id (INT, PK)
- license_plate_number (VARCHAR)
- starting_price (DECIMAL)
- current_price (DECIMAL)
- start_time (DATETIME)
- end_time (DATETIME)
- winner_id (INT, FK)
- status (VARCHAR)

bids
- id (INT, PK)
- auction_id (INT, FK)
- user_id (INT, FK)
- amount (DECIMAL)
- bid_time (DATETIME)
```

## Lưu Ý Phát Triển

- Password đang được lưu dưới dạng plain text - cần hash trước khi đưa vào production
- Chưa có rate limiting cho API
- Cần thêm logging cho server

## Thành viên nhóm

## Acknowledgments

- Đây là dự án phục vụ mục đích học tập
- Cảm ơn giảng viên: Bùi Dương Thế đã hướng dẫn
