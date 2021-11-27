FROM python:3.6

RUN mkdir -p /holidays
WORKDIR /holidays/

COPY . /holidays/
RUN pip install --upgrade pip && pip install -r requirements.txt

EXPOSE 8000

CMD ["python", "./server/manage.py", "runserver", "0.0.0.0:8000"]