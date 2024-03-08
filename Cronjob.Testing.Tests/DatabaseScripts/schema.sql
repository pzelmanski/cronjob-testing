create table raw_logs
(
    id uuid primary key,
    message text not null,
    severity int not null,
    source text not null,
    timestamp timestamp not null,
    additional_field1 text,
    additional_field2 text
);

create table transformed_logs
(
    id uuid primary key,
    message text,
    severity int not null
);