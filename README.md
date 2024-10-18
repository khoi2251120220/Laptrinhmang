# AuctionApp

AuctionApp là một ứng dụng đấu giá biển số xe sử dụng C# với giao tiếp Socket giữa Client và Server.

## Cấu trúc Dự án

Dự án bao gồm ba phần chính:

1. `Server`: Phần backend của ứng dụng, xử lý logic đấu giá và tương tác với cơ sở dữ liệu.
2. `Client`: Phần frontend của ứng dụng, giao diện người dùng để tham gia đấu giá.
3. `Shared`: Chứa các model dùng chung giữa Client và Server.

## Yêu cầu Hệ thống

- .NET 9.0 hoặc cao hơn
- MySQL Server

## Cài đặt

1. Cấu hình cơ sở dữ liệu:
   - Tạo một cơ sở dữ liệu mới trong MySQL Server.
   - Cập nhật thông tin kết nối trong file `.env` trong thư mục `Server`.

2. Tạo file `.env` trong thư mục `Server` với nội dung sau:
   ```
   DB_USER=your_username
   DB_PASSWORD=your_password
   DB_NAME=auction_db
   ```
   Thay thế `your_username` và `your_password` bằng thông tin đăng nhập MySQL của bạn.

## Chạy Ứng dụng

1. Chạy Server:
   ```
   cd Server
   dotnet run
   ```
   Server sẽ tự động khởi tạo cơ sở dữ liệu và thêm dữ liệu mẫu nếu cần.

2. Trong một terminal khác, chạy Client:
   ```
   cd Client
   dotnet run
   ```

3. Client sẽ kết nối với Server và hiển thị thông tin về các phiên đấu giá hiện có.

## Sử dụng Ứng dụng

- Server sẽ lắng nghe các kết nối từ Client trên địa chỉ IP và cổng được cấu hình trong file `.env`.
- Client sẽ kết nối tới Server và nhận thông tin về các phiên đấu giá.

