Ubuntu 17.10
[*] Cài đặt các `Prerequirement Software` và update bản mới nhất
	* git
	* Postgresql (Lưu ý password để trống)
	* Redis 3.6.x
	* TimescaleDB 0.3
	* RabbitMQ 3.6.x
	* nmp
	* nodejs

[*] chạy các service lên:
	*  Postgresql
*  Redis-server
[*] Tạo file `.env` ở thư mục gốc và lưu lại
[*] tạo database bằng lệnh:
> npm run setup:db:create

[*] Cách remove password của Postgresql:
	* mở file `/etc/postgresql/9.6/main/pg_hba.conf` và thay đổi cột   `method` thành `trust` (giá trị cũ đó là `peer`) ở hàng có mà giá trị user là `postgres`.
	* restart lại service postgresql 

