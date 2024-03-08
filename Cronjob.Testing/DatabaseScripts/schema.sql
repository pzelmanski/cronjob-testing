create table raw_logs
(
    id uuid primary key,
    message text not null,
    severity int not null
)