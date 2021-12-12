from django.db import models


class User(models.Model):
    login = models.CharField(max_length=20)
    password = models.CharField(max_length=40)


class Conference(models.Model):
    name = models.CharField(max_length=20)


class Guest(models.Model):
    conference_id = models.ForeignKey(Conference, on_delete=models.CASCADE)
    user_id = models.ForeignKey(User, on_delete=models.CASCADE)


class Message(models.Model):
    conference_id = models.ForeignKey(Conference, on_delete=models.CASCADE)
    user_id = models.ForeignKey(User, on_delete=models.CASCADE)
    text = models.TextField()
