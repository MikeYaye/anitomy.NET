/* This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. See the LICENCE file for more info.*/

#include "stdafx.h"
#include <string>
#include "anitomy/anitomy/anitomy.h"
#include "atlsafe.h"

/**
* \brief Convert anitomy string to std string
*/
std::string convert_to_string(anitomy::string_t input_str) {
	std::wstring input_w_str(input_str.c_str());
	std::string str(input_w_str.begin(), input_w_str.end());
	return str;
}

/**
* \brief Convert array to LPSAFEARRAY
*/
LPSAFEARRAY convert_to_safe_array(std::vector<std::string> input_array) {
	CComSafeArray<BSTR> output(input_array.size());
	int i = 0;
	for (std::vector<std::string>::const_iterator x = input_array.begin(); x != input_array.end(); ++x, ++i) {
		output.SetAt(i, A2BSTR_EX((*x).c_str()), FALSE);
	}
	return output.Detach();
}


/**
 * \brief Parses anime file name to an array of elements
 */
extern "C" __declspec(dllexport) LPSAFEARRAY parse_anime_file_name(const wchar_t* file_name,
                                                                   const wchar_t* ignored_strings[],
                                                                   const int ignored_strings_length,
                                                                   const wchar_t* allowed_delimiters,
                                                                   const bool parse_episode_number,
                                                                   const bool parse_episode_title,
                                                                   const bool parse_file_extension,
                                                                   const bool parse_release_group) {
	anitomy::Anitomy anitomy;

	// Define options
	std::vector<anitomy::string_t> ignored_strings_str;
	for (int x = 0; x < ignored_strings_length; x++) {
		ignored_strings_str.push_back(ignored_strings[x]);
	}
	anitomy.options().ignored_strings = ignored_strings_str;
	anitomy.options().allowed_delimiters = allowed_delimiters;
	anitomy.options().parse_episode_number = parse_episode_number;
	anitomy.options().parse_episode_title = parse_episode_title;
	anitomy.options().parse_file_extension = parse_file_extension;
	anitomy.options().parse_release_group = parse_release_group;

	// Parse file and get the elements
	anitomy.Parse(file_name);
	auto elements = anitomy.elements();

	// Push all elements to the results array based on the category
	std::vector<std::string> results;
	for (int x = anitomy::ElementCategory::kElementAnimeSeason; x != anitomy::ElementCategory::kElementVolumePrefix; x++) {
		auto category = static_cast<anitomy::ElementCategory>(x);
		results.push_back(convert_to_string(elements.get(category)));
	}

	return convert_to_safe_array(results);
}