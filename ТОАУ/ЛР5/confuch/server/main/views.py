from django.shortcuts import render
from django.http import HttpResponse, HttpResponseRedirect

from .models import *


def index(request):
    if request.method == 'GET':
        login = request.session.get('login', '')
        data = {
            'login': login,
        }
        return render(request, "index.html", data)
    return HttpResponseRedirect("/")


def sign_in(request):
    if request.method == 'POST':
        login = request.POST.get("login", "")
        password = request.POST.get("password", "")
        if does_user_exist(login, password):
            request.session['id'] = login
    return HttpResponseRedirect("/")


def sign_up(request):
    if request.method == 'GET':
        login = request.GET.get("login", "")
        password = request.GET.get("password", "")
        if not does_user_exist(login, password):
            user = User.objects.create(
                login=login,
                password=password
            )
            user.save()
            request.session['id'] = user.id
    return HttpResponseRedirect("/")


def sign_out(request):
    if request.method == 'GET':
        request.session.flush()
    return HttpResponseRedirect("/")


def users(request):
    if request.method == 'GET':
        return HttpResponse(
            content=', '.join(map(lambda u: u.login, list(
                User.objects.all()
            )))
        )
    return HttpResponseRedirect("/")


def conference(request):
    if request.method == 'GET':
        return HttpResponse(
            content='<br>'.join(map(lambda u: u.login, list(
                Message.objects.filter(conference_id=request.GET.get('id', ''))
            )))
        )
    return HttpResponseRedirect("/")


def conferences(request):
    if request.method == 'GET':
        return HttpResponse(
            content=', '.join(map(lambda u: u.login, list(
                Guest.objects.filter(user_id=request.session.get('login', ''))
            )))
        )
    return HttpResponseRedirect("/")


def add_guest(request):
    if request.method == 'GET':
        pass
    return HttpResponseRedirect("/")


def add_message(request):
    if request.method == 'GET':
        pass
    return HttpResponseRedirect("/")


def create_conference(request):
    if request.method == 'GET':
        pass
    return HttpResponseRedirect("/")


def does_user_exist(login, password):
    user = User.objects.get(
        login=login,
        password=password
    )
    return user