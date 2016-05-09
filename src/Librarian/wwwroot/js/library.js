(function () {
    function LibraryController($scope, $http) {
        var self = this;
        self.enterLibrary = false;
        self.showRating = false;
        self.newBookForm = true;
        self.showTable = true;
        self.showMessage = false;
        self.showMarking = true;
        function Array(max) {
            var arr = [];
            var i = 0;
            while (i <= max) {                
                arr.push(i);
                i++;
            }
            return arr;
        };        
        self.arrRating = Array(10);
        self.selectLibrary = function (libraryId) {
            $http.get("/Book/List?libraryId=" + libraryId)
                .success(function (data) {
                    document.getElementById('list-books').style.display = "block";
                    self.enterLibrary = true;
                    self.showRating = false;                    
                    self.showTable = true;
                    self.showMessage = false;
                    self.showMarking = false;
                    self.books = data.Data;                    
                }).error(function (data) {
                    self.enterLibrary = false;                    
                });
        };
        self.takeBook = function (bookId) {
            $http.post("/Book/Take?bookId=" + bookId)
                .success(function (data) {
                    self.message = data.Message;
                    self.showTable = false;
                    self.showMessage = true;
                    self.showMarking = false;
                }).error(function (data) {
                    self.message = "Не удалось взять книгу. Попробуйте еще раз."
                });
        };
        self.returnBook = function (bookId) {
            $http.post("/Book/Return?bookId=" + bookId)
                .success(function (data) {
                    self.message = data.Message;
                    if (data.Success == true) {
                        self.showTable = false;
                        self.showRating = true;
                        self.showMarking = false;
                        self.currentBook = { Id: data.BookId, Name: data.BookName, Author: data.BookAuthor };
                    }
                }).error(function (data) {
                    self.message = "Не удалось вернуть книгу. Попробуйте еще раз.";
                });
        };
        self.putRating = function (bookId, ratingMark, ratingComment) {
            var params;
            if (ratingMark) {
                if (ratingComment)
                    params = "ratingMark=" + ratingMark + "&ratingComment=" + ratingComment;
                else
                    params = "ratingMark=" + ratingMark;
            }
            else {
                if (ratingComment)
                    params = "ratingComment=" + ratingCommen
                else
                    params = "";
            }
            $('#id-rating-mark').val("0");
            $('#id-rating-comment').val("");
            $http.post("/Book/Estimate?bookId=" + bookId + "&" + params)
                .success(function (data) {
                    self.message = data.Message;
                    self.showRating = false;
                    self.showMessage = true;
                }).error(function (data) {
                    self.showRating = false;
                });
        };
        self.addBook = function () {
            self.newBookForm = false;
        };
        self.addNewBook = function (newBookName, newBookAuthor) {
            $http.post("/Book/Add?bookName=" + newBookName + "&bookAuthor=" + newBookAuthor)
            .success(function (data) {
                self.newBookForm = true;
            })
            .error(function (data) {
            });
        };
        self.ratingBook = function (bookId) {            
            $http.post("/Book/GetRating?bookId=" + bookId)
                .success(function (data) {
                    self.showTable = false;
                    self.showMarking = true;
                    self.markResult = data.Data;
                }).error(function (data) {
                });
        };
    };
    var app = angular.module('library', []);
    app.controller("libraryController", LibraryController);    
})();
