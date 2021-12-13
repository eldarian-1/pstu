from .logic import *
from .models import *
from django.shortcuts import render
from django.http import HttpResponse, HttpResponseRedirect


def index(request):
    if request.method == 'GET':
        id = request.session.get('id', '')
        if id != '':
            pass
        data = {
            'id': id,
        }
        return render(request, "index.html", data)
    return HttpResponseRedirect("/")


def sign_in(request):
    if request.method == 'POST':
        login = request.POST.get("login", "")
        password = request.POST.get("password", "")
        id = does_user_exist(login, password)
        if id:
            request.session['id'] = id
    return HttpResponseRedirect("/")


def sign_up(request):
    if request.method == 'POST':
        login = request.POST.get("login", "")
        password = request.POST.get("password", "")
        if not does_user_exist(login, password):
            request.session['id'] = create_user(login, password)
    return HttpResponseRedirect("/")


def sign_out(request):
    if request.method == 'GET':
        request.session.flush()
    return HttpResponseRedirect("/")


def users(request):
    if request.method == 'GET':
        data = {
            'id': request.session.get('id', ''),
            'users': User.objects.all()
        }
        return render(request, "users.html", data)
    return HttpResponseRedirect("/")


def conference(request):
    if request.method == 'GET':
        conference_id = request.GET.get('id', '')
        data = {
            'id': request.session.get('id', ''),
            'conference': get_conference(conference_id),
            'guests': get_guests(conference_id),
            'messages': get_messages(conference_id)
        }
        return render(request, "conference.html", data)
    return HttpResponseRedirect("/")


def conferences(request):
    if request.method == 'GET':
        user_id = request.session.get('id', '')
        conference_s = get_conferences(user_id)
        data = {
            'id': request.session.get('id', ''),
            'conferences': conference_s
        }
        return render(request, "conferences.html", data)
    return HttpResponseRedirect("/")


def create_conference(request):
    if request.method == 'POST':
        user_id = request.session.get('id', '')
        name = request.POST.get("name", "")
        conference_id = add_conference(name, user_id)
        return HttpResponseRedirect("/conference?id=" + str(conference_id))
    return HttpResponseRedirect("/")


def add_guest_list(request):
    if request.method == 'GET':
        conference_id = request.GET.get("conference_id", "")
        data = {
            'id': request.session.get('id', ''),
            'conference_id': conference_id,
            'users': User.objects.all()
        }
        return render(request, "add_guest.html", data)
    return HttpResponseRedirect("/")


def add_guest(request):
    if request.method == 'GET':
        conference_id = request.GET.get("conference_id", "")
        user_id = request.GET.get("user_id", "")
        add_user(conference_id, user_id)
        return HttpResponseRedirect("/conference?id=" + conference_id)
    return HttpResponseRedirect("/")


def add_message(request):
    if request.method == 'POST':
        conference_id = request.POST.get("conference_id", "")
        user_id = request.POST.get("user_id", "")
        message = request.POST.get("message", "")
        create_message(conference_id, user_id, message)
        return HttpResponseRedirect("/conference?id=" + conference_id)
    return HttpResponseRedirect("/")
