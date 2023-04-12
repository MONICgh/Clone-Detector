package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestSimpleLevenshtain(t *testing.T) {

	assert := assert.New(t)

	a := " a "
	ab := " a \n b "
	bb := " b \n b "

	assert.Equal(Levenshtain(a, ab), 1, "dist("+a+", "+ab+"), must be 1")
	assert.Equal(Levenshtain(a, bb), 2, "dist("+a+", "+bb+"), must be 2")
	assert.Equal(Levenshtain(ab, bb), 1, "dist("+ab+", "+bb+"), must be 1")
}

func TestMediumLevenshtain(t *testing.T) {

	assert := assert.New(t)

	s1 := " first \n second \n third \n end "
	s2 := " second \n third \n end "
	s3 := " first \n delete \n third \n end "

	assert.Equal(Levenshtain(s1, s2), 1, "dist("+s1+", "+s2+"), must be 1")
	assert.Equal(Levenshtain(s1, s3), 1, "dist("+s1+", "+s3+"), must be 1")
	assert.Equal(Levenshtain(s3, s2), 2, "dist("+s3+", "+s2+"), must be 2")
}
