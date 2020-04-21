DELETE FROM Vote;
DELETE FROM TopicTag;
DELETE FROM Topic;
DELETE FROM UserInterest;
DELETE FROM Interest;
DELETE FROM UserBadge;
DELETE FROM Badge;
DELETE FROM Permission;
DELETE FROM UserAccount;

COMMIT;

INSERT INTO
    UserAccount (
        Username,
        FirstName,
        LastName,
        Password,
        Email
    )
VALUES
    (
        'MonicaTanios',
        'Monica',
        'Tanios',
        'Monica123',
        'monica2017170457@cis.asu.eg'
    );

INSERT INTO
    UserAccount (
        Username,
        FirstName,
        LastName,
        Password,
        points,
        Email
    )
VALUES
    (
        'MichelineMedhat',
        'Micheline',
        'Medhat',
        'Micha123',
        30,
        'micha2017170457@cis.asu.eg'
    );

INSERT INTO
    UserAccount (
        Username,
        FirstName,
        LastName,
        Password,
        Email
    )
VALUES
    (
        'MichaelSafwat',
        'Michael',
        'Safwat',
        'Michael123',
        'michael2017170457@cis.asu.eg'
    );

INSERT INTO
    UserAccount (
        Username,
        FirstName,
        LastName,
        Password,
        points,
        Email
    )
VALUES
    (
        'YoussefRaafat',
        'Youssef',
        'Raafat',
        'Youssef123',
        30,
        'youssefl2017170457@cis.asu.eg'
    );

INSERT INTO
    UserAccount (
        Username,
        FirstName,
        LastName,
        Password,
        points,
        Email
    )
VALUES
    (
        'MonicaAtef',
        'Monica',
        'Atef',
        'Monica2123',
        50,
        'monica22017170457@cis.asu.eg'
    );

INSERT INTO
    Permission
VALUES
    (
        permission_seq.NEXTVAL,
        'Few Privilages',
        'User can comment and vote on topics.'
    );

INSERT INTO
    Permission
VALUES
    (
        permission_seq.NEXTVAL,
        'Relatively High Privilages',
        'User can edit on others topics.'
    );

INSERT INTO
    Permission
VALUES
    (
        permission_seq.NEXTVAL,
        'Many Privilages',
        'User has access to add and remove other topics.'
    );

INSERT INTO
    Badge
VALUES
    ('New User', 30, 0);

INSERT INTO
    Badge
VALUES
    ('ShutterBug', 50, 1);

INSERT INTO
    Badge
VALUES
    ('ComboCommenter', 70, 2);

INSERT INTO
    UserBadge
VALUES
    ('MichelineMedhat', 'New User');

INSERT INTO
    UserBadge
VALUES
    ('MichaelSafwat', 'New User');

INSERT INTO
    UserBadge
VALUES
    ('YoussefRaafat', 'New User');

INSERT INTO
    UserBadge
VALUES
    ('MonicaAtef', 'ShutterBug');

INSERT INTO
    UserBadge
VALUES
    ('MonicaTanios', 'New User');

INSERT INTO
    Interest
VALUES
    (interest_seq.NEXTVAL, 'Movies');

INSERT INTO
    Interest
VALUES
    (interest_seq.NEXTVAL, 'TV Series');

INSERT INTO
    Interest
VALUES
    (interest_seq.NEXTVAL, 'Programming');

INSERT INTO
    UserInterest
VALUES
    ('MichaelSafwat', 2);

INSERT INTO
    UserInterest
VALUES
    ('MonicaAtef', 1);

INSERT INTO
    UserInterest
VALUES
    ('YoussefRaafat', 0);

INSERT INTO
    Topic
VALUES
    (
        'Black Mirror',
        'Z:/BlackMirror',
        'MichaelSafwat'
    );

INSERT INTO
    Topic
VALUES
    (
        'Begin coding with c++ or c#?',
        'Z:/Programming',
        'YoussefRaafat'
    );

INSERT INTO
    Topic
VALUES
    ('Interstellar', 'Z:/Movies', 'MichelineMedhat');

INSERT INTO
    TopicTag
VALUES
    ('Black Mirror', 1);

INSERT INTO
    TopicTag
VALUES
    ('Begin coding with c++ or c#?', 2);

INSERT INTO
    TopicTag
VALUES
    ('Interstellar', 0);

INSERT INTO
    Vote
VALUES
    (
        vote_seq.NEXTVAL,
        'Up',
        'Interstellar',
        'MonicaTanios'
    );

INSERT INTO
    Vote
VALUES
    (
        vote_seq.NEXTVAL,
        'Down',
        'Black Mirror',
        'YoussefRaafat'
    );

INSERT INTO
    Vote
VALUES
    (
        vote_seq.NEXTVAL,
        'Up',
        'Begin coding with c++ or c#?',
        'MonicaAtef'
    );

INSERT INTO
    Vote
VALUES
    (
        vote_seq.NEXTVAL,
        'Up',
        'Begin coding with c++ or c#?',
        'MonicaTanios'
    );

COMMIT;