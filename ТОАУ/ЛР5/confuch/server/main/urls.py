from django.urls import path
from . import views

urlpatterns = [
    path('', views.index),
    path('sign_in', views.sign_in),
    path('sign_up', views.sign_up),
    path('sign_out', views.sign_out),
    path('users', views.users),
    path('conference', views.conference),
    path('conferences', views.conferences),
    path('add_guest', views.add_guest),
    path('add_message', views.add_message),
    path('create_conference', views.create_conference),
]
