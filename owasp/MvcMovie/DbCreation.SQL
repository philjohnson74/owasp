create table if not exists Movie
(
    id int auto_increment,
    title text not null,
    genre text null,
    constraint Movie_id_uindex
    unique (id)
    );

alter table Movie
    add primary key (id);

insert into Movie (title, genre) values ('Terminator', 'SciFi');
insert into Movie (title, genre) values ('Jingle all the Way', 'Comedy');
insert into Movie (title, genre) values ('Pumping Iron', 'Documentary');

grant drop on table Movie to WebSiteUser;