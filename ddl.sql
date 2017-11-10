CREATE TABLE author
(
    id INTEGER DEFAULT nextval('author_id_seq'::regclass) PRIMARY KEY NOT NULL,
    name TEXT NOT NULL,
    ob_url TEXT
);
CREATE TABLE book
(
    id INTEGER DEFAULT nextval('book_id_seq'::regclass) PRIMARY KEY NOT NULL,
    id_genre INTEGER,
    title TEXT NOT NULL,
    image_url TEXT,
    publication_date DATE DEFAULT '1900-01-01'::date NOT NULL,
    isbn_10 TEXT,
    isbn_13 INTEGER NOT NULL,
    description TEXT,
    id_publisher INTEGER,
    CONSTRAINT book_id_genre_fkey FOREIGN KEY (id_genre) REFERENCES genre (id),
    CONSTRAINT book_id_publisher_fkey FOREIGN KEY (id_publisher) REFERENCES publisher (id)
);
CREATE TABLE book_author
(
    id INTEGER DEFAULT nextval('book_author_id_seq'::regclass) PRIMARY KEY NOT NULL,
    id_author INTEGER,
    id_book INTEGER,
    CONSTRAINT book_author_id_author_fkey FOREIGN KEY (id_author) REFERENCES author (id),
    CONSTRAINT book_author_id_book_fkey FOREIGN KEY (id_book) REFERENCES book (id)
);
CREATE TABLE genre
(
    id INTEGER DEFAULT nextval('genre_id_seq'::regclass) PRIMARY KEY NOT NULL,
    name TEXT NOT NULL
);
CREATE TABLE publisher
(
    id INTEGER DEFAULT nextval('publisher_id_seq'::regclass) PRIMARY KEY NOT NULL,
    name TEXT NOT NULL
);
CREATE TABLE shop
(
    id INTEGER DEFAULT nextval('shop_id_seq'::regclass) PRIMARY KEY NOT NULL,
    name TEXT NOT NULL,
    zip TEXT,
    street TEXT,
    city TEXT,
    position TEXT
);
CREATE TABLE storage
(
    id INTEGER DEFAULT nextval('storage_id_seq'::regclass) PRIMARY KEY NOT NULL,
    id_shop INTEGER,
    id_book INTEGER,
    amount INTEGER DEFAULT 0 NOT NULL,
    CONSTRAINT storage_id_shop_fkey FOREIGN KEY (id_shop) REFERENCES shop (id),
    CONSTRAINT storage_id_book_fkey FOREIGN KEY (id_book) REFERENCES book (id)
);
