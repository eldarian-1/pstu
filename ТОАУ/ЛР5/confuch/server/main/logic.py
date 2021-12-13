import datetime
from .models import *


def does_user_exist(login, password):
    users = list(User.objects.filter(
        login=login,
        password=password
    ))
    return False if not len(users) else users[0].id


def create_user(login, password):
    user = User.objects.create(
        login=login,
        password=password
    )
    user.save()
    return user.id


def add_user(conference_id, user_id):
    Guest.objects.create(
        conference_id=get_conference(conference_id),
        user_id=get_user(user_id)
    ).save()


def create_message(conference_id, user_id, message):
    Message.objects.create(
        conference_id=get_conference(conference_id),
        user_id=get_user(user_id),
        text=message,
        date=datetime.datetime.now()
    ).save()


def add_conference(name, user_id):
    conference = Conference.objects.create(
        name=name
    )
    conference.save()
    add_user(conference.id, user_id)
    return conference.id


def get_user(user_id):
    return User.objects.get(id=int(user_id))


def get_conference(conference_id):
    return Conference.objects.get(id=int(conference_id))


def get_guests(conference_id):
    return list(Guest.objects.filter(conference_id=int(conference_id)))


def get_conferences(user_id):
    return map(
        lambda guest: guest.conference_id,
        list(Guest.objects.filter(user_id=get_user(user_id)))
    )


def get_messages(conference_id):
    return list(Message.objects.filter(conference_id=conference_id))
