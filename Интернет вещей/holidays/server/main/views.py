import datetime

from django.http import HttpResponse

def index(request):
    return HttpResponse(
        "Работа студента группы РИС-19-1б<br>Эльдара Миннахметова<br>Python Django - %s"
        % datetime.datetime.now().strftime("%d.%m.%Y %H:%M:%S")
    )
